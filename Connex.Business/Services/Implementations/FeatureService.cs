using AutoMapper;
using Connex.Business.Extensions;
using Connex.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

namespace Connex.Business.Services.Implementations;

public class FeatureService : IFeatureService
{
    private readonly IFeatureRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public FeatureService(IFeatureRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(FeatureCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (!dto.Image.ValidateSize(2))
        {
            ModelState.AddModelError("Image", "Şəkilin ölçüsü 2 mb dan artıq ola bilməz");
            return false;
        }
        if (!dto.Image.ValidateType())
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
            return false;
        }

        foreach (var detail in dto.FeatureDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.FeatureDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var feature = _mapper.Map<Feature>(dto);

        string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        feature.ImagePath = imagePath;

        await _repository.CreateAsync(feature);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var feature = await _repository.GetAsync(id);

        if (feature is null)
            throw new NotFoundException($"{id} bu id'də məlumat tapılmadı");

        _repository.Delete(feature);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(feature.ImagePath);
    }

    public async Task<List<FeatureGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var features = await _repository.GetAll(_getIncludeFunc(language)).ToListAsync();

        var dtos = _mapper.Map<List<FeatureGetDto>>(features);

        return dtos;
    }

    public async Task<FeatureGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var feature = await _repository.GetAsync(id, _getIncludeFunc(language));


        if (feature is null)
            throw new NotFoundException($"{id} bu id'də məlumat tapılmadı");

        var dto = _mapper.Map<FeatureGetDto>(feature);

        return dto;
    }

    public async Task<FeatureUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var feature = await _repository.GetAsync(id, x => x.Include(x => x.FeatureDetails));

        if (feature is null)
            throw new NotFoundException($"{id} bu id'də məlumat tapılmadı");

        var dto = _mapper.Map<FeatureUpdateDto>(feature);

        return dto;
    }

    public async Task<bool> UpdateAsync(FeatureUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existFeature = await _repository.GetAsync(dto.Id, x => x.Include(x => x.FeatureDetails));

        if (existFeature is null)
            throw new NotFoundException($"{dto.Id} bu id'də məlumat tapılmadı");

        if (!dto.Image?.ValidateSize(2) ?? false)
        {
            ModelState.AddModelError("Image", "Şəkilin ölçüsü 2 mb dan artıq ola bilməz");
            return false;
        }
        if (!dto.Image?.ValidateType() ?? false)
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
            return false;
        }

        foreach (var detail in dto.FeatureDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.FeatureDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        existFeature = _mapper.Map(dto, existFeature);

        if (dto.Image is { })
        {
            string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            await _cloudinaryService.FileDeleteAsync(existFeature.ImagePath);
            existFeature.ImagePath = newImagePath;
        }

        _repository.Update(existFeature);
        await _repository.SaveChangesAsync();

        return true;

    }


    private void _checkLanguageId(ref Languages language)
    {
        foreach (var l in Enum.GetNames(typeof(Languages)))
        {
            if (language.ToString() == l)
                return;
        }

        language = Languages.Azerbaijan;
    }
    private bool _checkLanguageId(int id)
    {
        foreach (var l in Enum.GetValues(typeof(Languages)))
        {
            if (id == (int)l)
                return true;
        }

        return false;
    }



    private Func<IQueryable<Feature>, IIncludableQueryable<Feature, object>> _getIncludeFunc(Languages language)
    {

        return x => x.Include(x => x.FeatureDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
    }
}

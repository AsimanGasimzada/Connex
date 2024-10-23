
using AutoMapper;
using Connex.Business.Extensions;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Digests;

namespace Connex.Business.Services.Implementations;

public class LanguageService : ILanguageService
{
    private readonly ILanguageRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public LanguageService(ILanguageRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(LanguageCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var isExist = await _repository.IsExistAsync(x => x.Code.ToLower() == dto.Code.ToLower());

        if (isExist)
        {
            ModelState.AddModelError("Code", "Bu kod artıq mövcuddur");
            return false;
        }


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


        var language = _mapper.Map<Language>(dto);

        string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        language.ImagePath = imagePath;

        await _repository.CreateAsync(language);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var language = await _repository.GetAsync(id);


        if (language is null)
            throw new NotFoundException($"{id} bu id-də məlumat tapılmadı");

        _repository.Delete(language);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<LanguageGetDto>> GetAllAsync()
    {
        var languages = await _repository.GetAll().ToListAsync();

        var dtos = _mapper.Map<List<LanguageGetDto>>(languages);

        return dtos;
    }

    public async Task<LanguageGetDto> GetAsync(int id)
    {
        var language = await _repository.GetAsync(id);

        if (language is null)
            throw new NotFoundException($"{id} bu id-də məlumat tapılmadı");

        var dto = _mapper.Map<LanguageGetDto>(language);

        return dto;
    }

    public async Task<LanguageUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var language = await _repository.GetAsync(id);

        if (language is null)
            throw new NotFoundException($"{id} bu id-də məlumat tapılmadı");

        var dto = _mapper.Map<LanguageUpdateDto>(language);

        return dto;
    }

    public async Task<LanguageGetDto> GetWithCodeAsync(string code)
    {
        var language = await _repository.GetAsync(x => x.Code.ToLower() == code.ToLower());


        if (language is null)
            language = await _repository.GetAsync(x => x.IsDefault);

        var dto = _mapper.Map<LanguageGetDto>(language);

        return dto;
    }

    public async Task<bool> UpdateAsync(LanguageUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existLanguage = await _repository.GetAsync(dto.Id);


        if (existLanguage is null)
            throw new NotFoundException($"{dto.Id} bu id-də məlumat tapılmadı");


        var isExist = await _repository.IsExistAsync(x => x.Code.ToLower() == dto.Code.ToLower() && x.Id != dto.Id);

        if (isExist)
        {
            ModelState.AddModelError("Code", "Bu kod artıq mövcuddur");
            return false;
        }


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


        existLanguage = _mapper.Map(dto, existLanguage);

        if (dto.Image is { })
        {
            string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            await _cloudinaryService.FileDeleteAsync(existLanguage.ImagePath);
            existLanguage.ImagePath = newImagePath;
        }

        _repository.Update(existLanguage);
        await _repository.SaveChangesAsync();

        return true;
    }
}

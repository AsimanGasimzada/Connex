using AutoMapper;
using Connex.Business.Extensions;
using Connex.Core.Enums;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Connex.Business.Services.Implementations;

public class ServiceService : IServiceService
{
    private readonly IServiceRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public ServiceService(IServiceRepository repository, IMapper mapper, ICloudinaryService cloudinaryService)
    {
        _repository = repository;
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
    }

    public async Task<bool> CreateAsync(ServiceCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (!dto.Image.ValidateSize(2))
        {
            ModelState.AddModelError("Image", "Şəklin ölçüsü 2 mb-dan böyük olmamalıdır");
            return false;
        }
        if (!dto.Image.ValidateType())
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatı daxil edə bilərsiniz.");
            return false;
        }

        foreach (var detail in dto.ServiceDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.ServiceDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var service = _mapper.Map<Service>(dto);

        string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        service.ImagePath = imagePath;

        await _repository.CreateAsync(service);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var service = await _repository.GetAsync(id);

        if (service is null)
            throw new NotFoundException($"{id}-bu id də servis mövcud deyil");

        _repository.Delete(service);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(service.ImagePath);

    }

    public async Task<List<ServiceGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var services = await _repository.GetAll(_getIncludeFunc(language)).ToListAsync();

        var dtos = _mapper.Map<List<ServiceGetDto>>(services);

        return dtos;
    }

    public async Task<ServiceGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var service = await _repository.GetAsync(id, _getIncludeFunc(language));

        if (service is null)
            throw new NotFoundException($"{id}-bu id də servis mövcud deyil");

        var dto = _mapper.Map<ServiceGetDto>(service);

        return dto;
    }

    public async Task<ServiceUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var service = await _repository.GetAsync(id, x => x.Include(x => x.ServiceDetails));

        if (service is null)
            throw new NotFoundException($"{id}-bu id də servis mövcud deyil");

        var dto = _mapper.Map<ServiceUpdateDto>(service);

        return dto;
    }

    public async Task<bool> UpdateAsync(ServiceUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existService = await _repository.GetAsync(dto.Id, x => x.Include(x => x.ServiceDetails));

        if (existService is null)
            throw new NotFoundException($"{dto.Id}-bu id də servis mövcud deyil");

        if (!dto.Image?.ValidateSize(2) ?? false)
        {
            ModelState.AddModelError("Image", "Şəklin ölçüsü 2 mb-dan böyük olmamalıdır");
            return false;
        }
        if (!dto.Image?.ValidateType() ?? false)
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatı daxil edə bilərsiniz.");
            return false;
        }

        foreach (var detail in dto.ServiceDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.ServiceDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        existService = _mapper.Map(dto, existService);

        if(dto.Image is { })
        {
            string newImagePath=await _cloudinaryService.FileCreateAsync(dto.Image);
            await _cloudinaryService.FileDeleteAsync(existService.ImagePath);

            existService.ImagePath=newImagePath;
        }

        _repository.Update(existService);
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



    private Func<IQueryable<Service>, IIncludableQueryable<Service, object>> _getIncludeFunc(Languages language)
    {

        return x => x.Include(x => x.ServiceDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
    }
}

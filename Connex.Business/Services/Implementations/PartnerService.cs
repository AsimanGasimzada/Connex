
using AutoMapper;
using Connex.Business.Exceptions;
using Connex.Business.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Connex.Business.Services.Implementations;

public class PartnerService : IPartnerService
{
    private readonly IPartnerRepository _repository;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IMapper _mapper;
    public PartnerService(IPartnerRepository repository, ICloudinaryService cloudinaryService, IMapper mapper)
    {
        _repository = repository;
        _cloudinaryService = cloudinaryService;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(PartnerCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (!dto.Image.ValidateSize(2))
        {
            ModelState.AddModelError("Image", "Şəklin ölçüsü 2 mb-dan artıq ola bilməz");
            return false;
        }
        if (!dto.Image.ValidateType())
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatında fayl yükləyə bilərsiniz.");
            return false;
        }

        var partner = _mapper.Map<Partner>(dto);

        string filePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        partner.ImagePath = filePath;

        await _repository.CreateAsync(partner);
        await _repository.SaveChangesAsync();

        return true;

    }

    public async Task DeleteAsync(int id)
    {
        var partner = await _repository.GetAsync(id);

        if (partner is null)
            throw new NotFoundException($"{id}-bu idli partnyor mövcud deyil.");

        _repository.Delete(partner);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(partner.ImagePath);

    }

    public async Task<List<PartnerGetDto>> GetAllAsync()
    {
        var partners = await _repository.GetAll().ToListAsync();

        var dtos = _mapper.Map<List<PartnerGetDto>>(partners);

        return dtos;
    }

    public async Task<PartnerGetDto> GetByIdAsync(int id)
    {
        var partner = await _repository.GetAsync(id);

        if (partner is null)
            throw new NotFoundException($"{id}-bu idli partnyor mövcud deyil.");

        var dto = _mapper.Map<PartnerGetDto>(partner);

        return dto;
    }

    public async Task<PartnerUpdateDto> GetUpdatedPartnerAsync(int id)
    {
        var partner = await _repository.GetAsync(id);

        if (partner is null)
            throw new NotFoundException($"{id}-bu idli partnyor mövcud deyil.");

        var dto = _mapper.Map<PartnerUpdateDto>(partner);

        return dto;
    }

    public async Task<bool> UpdateAsync(PartnerUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existPartner = await _repository.GetAsync(dto.Id);

        if (existPartner is null)
            throw new NotFoundException($"{dto.Id}-bu idli partnyor mövcud deyil.");

        if (!dto.Image?.ValidateSize(2) ?? false)
        {
            ModelState.AddModelError("Image", "Şəklin ölçüsü 2 mb-dan artıq ola bilməz");
            return false;
        }
        if (!dto.Image?.ValidateType() ?? false)
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatında fayl yükləyə bilərsiniz.");
            return false;
        }

        existPartner = _mapper.Map(dto, existPartner);

        if (dto.Image is { })
        {
            string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            await _cloudinaryService.FileDeleteAsync(existPartner.ImagePath);

            existPartner.ImagePath = newImagePath;
        }

        _repository.Update(existPartner);
        await _repository.SaveChangesAsync();

        return true;

    }
}

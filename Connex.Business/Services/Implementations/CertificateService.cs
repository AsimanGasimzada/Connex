
using AutoMapper;
using Connex.Business.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Connex.Business.Services.Implementations;

public class CertificateService : ICertificateService
{
    private readonly ICertificateRepository _repository;
    private readonly IMapper _mapper;
    private readonly ICloudinaryService _cloudinaryService;

    public CertificateService(IMapper mapper, ICloudinaryService cloudinaryService, ICertificateRepository repository)
    {
        _mapper = mapper;
        _cloudinaryService = cloudinaryService;
        _repository = repository;
    }

    public async Task<bool> CreateAsync(CertificateCreateDto dto, ModelStateDictionary ModelState)
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

        string imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        var certificate = _mapper.Map<Certificate>(dto);

        certificate.ImagePath = imagePath;

        await _repository.CreateAsync(certificate);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var certificate = await _repository.GetAsync(id);

        if (certificate is null)
            throw new NotFoundException($"{id} bu id'də məlumat tapılmadı");

        _repository.Delete(certificate);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(certificate.ImagePath);
    }

    public async Task<List<CertificateGetDto>> GetAllAsync()
    {
        var certificates = await _repository.GetAll().ToListAsync();

        var dtos = _mapper.Map<List<CertificateGetDto>>(certificates);

        return dtos;
    }

    public async Task<CertificateGetDto> GetAsync(int id)
    {
        var certificate = await _repository.GetAsync(id);

        if (certificate is null)
            throw new NotFoundException($"{id} bu id'də məlumat tapılmadı");

        var dto = _mapper.Map<CertificateGetDto>(certificate);

        return dto;
    }

    public async Task<CertificateUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var certificate = await _repository.GetAsync(id);

        if (certificate is null)
            throw new NotFoundException($"{id} bu id'də məlumat tapılmadı");

        var dto = _mapper.Map<CertificateUpdateDto>(certificate);

        return dto;
    }

    public async Task<bool> UpdateAsync(CertificateUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existCertificate = await _repository.GetAsync(dto.Id);

        if (existCertificate is null)
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

        if (dto.Image is { })
        {
            string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            await _cloudinaryService.FileDeleteAsync(existCertificate.ImagePath);
            existCertificate.ImagePath = newImagePath;
        }

        _repository.Update(existCertificate);
        await _repository.SaveChangesAsync();

        return true;
    }
}

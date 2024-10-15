
using AutoMapper;
using Connex.Business.Extensions;
using Microsoft.EntityFrameworkCore;

namespace Connex.Business.Services.Implementations;

public class SliderService : ISliderService
{
    private readonly ISliderRepository _repository;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IMapper _mapper;


    public SliderService(ISliderRepository repository, ICloudinaryService cloudinaryService, IMapper mapper)
    {
        _repository = repository;
        _cloudinaryService = cloudinaryService;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(SliderCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;


        if (!dto.Image.ValidateSize(2))
        {
            ModelState.AddModelError("Image", "Şəklin həcmi 2 mb-dan çox olmamalıdır.");
            return false;
        }
        if (!dto.Image.ValidateType())
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatı daxil edin");
            return false;
        }


        var slider = _mapper.Map<Slider>(dto);

        string filePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        slider.ImagePath = filePath;

        await _repository.CreateAsync(slider);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var slider = await _repository.GetAsync(id);

        if (slider is null)
            return false;

        _repository.Delete(slider);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(slider.ImagePath);

        return true;
    }

    public async Task<List<SliderGetDto>> GetAllAsync()
    {
        var sliders = await _repository.GetAll().ToListAsync();

        var dtos = _mapper.Map<List<SliderGetDto>>(sliders);

        return dtos;
    }

    public async Task<SliderGetDto?> GetAsync(int id)
    {
        var slider = await _repository.GetAsync(id);

        if (slider is null)
            return null;

        var dto = _mapper.Map<SliderGetDto>(slider);

        return dto;
    }

    public async Task<SliderUpdateDto?> GetUpdatedSlider(int id)
    {
        var slider = await _repository.GetAsync(id);

        if (slider is null)
            return null;

        var dto = _mapper.Map<SliderUpdateDto>(slider);

        return dto;
    }

    public async Task<bool?> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existSlider = await _repository.GetAsync(dto.Id);

        if (existSlider is null)
            return null;

        if (dto.Image is { })
        {
            if (!dto.Image.ValidateSize(2))
            {
                ModelState.AddModelError("Image", "Şəklin həcmi 2 mb-dan çox olmamalıdır.");
                return false;
            }
            if (!dto.Image.ValidateType())
            {
                ModelState.AddModelError("Image", "Yalnız şəkil formatı daxil edin");
                return false;
            }
        }

        existSlider = _mapper.Map(dto, existSlider);

        if(dto.Image is { })
        {
            await _cloudinaryService.FileDeleteAsync(existSlider.ImagePath);

            string newFilePath = await _cloudinaryService.FileCreateAsync(dto.Image);

            existSlider.ImagePath=newFilePath;
        }

        _repository.Update(existSlider);
        await _repository.SaveChangesAsync();

        return true;
    }
}

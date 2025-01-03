﻿using AutoMapper;
using Connex.Business.Extensions;
using Connex.Core.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;

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


        foreach (var detail in dto.SliderDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.SliderDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var slider = _mapper.Map<Slider>(dto);

        string filePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        slider.ImagePath = filePath;

        await _repository.CreateAsync(slider);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var slider = await _repository.GetAsync(id);

        if (slider is null)
            throw new NotFoundException($"{id}-bu idli slayd mövcud deyildir.");

        _repository.Delete(slider);
        await _repository.SaveChangesAsync();

        await _cloudinaryService.FileDeleteAsync(slider.ImagePath);


    }

    public async Task<List<SliderGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var sliders = await _repository.GetAll(_getIncludeFunc(language)).ToListAsync();

        var dtos = _mapper.Map<List<SliderGetDto>>(sliders);

        return dtos;
    }

    public async Task<SliderGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var slider = await _repository.GetAsync(id, _getIncludeFunc(language));

        if (slider is null)
            throw new NotFoundException($"{id}-bu idli slayd mövcud deyildir.");

        var dto = _mapper.Map<SliderGetDto>(slider);

        return dto;
    }

    public async Task<SliderUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var slider = await _repository.GetAsync(id, x => x.Include(x => x.SliderDetails));

        if (slider is null)
            throw new NotFoundException($"{id}-bu idli slayd mövcud deyildir.");

        var dto = _mapper.Map<SliderUpdateDto>(slider);

        return dto;
    }

    public async Task<bool> UpdateAsync(SliderUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existSlider = await _repository.GetAsync(dto.Id, x => x.Include(x => x.SliderDetails));

        if (existSlider is null)
            throw new NotFoundException($"{dto.Id}-bu idli slayd mövcud deyildir.");

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


        foreach (var detail in dto.SliderDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.SliderDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }


        existSlider = _mapper.Map(dto, existSlider);

        if (dto.Image is { })
        {
            await _cloudinaryService.FileDeleteAsync(existSlider.ImagePath);

            string newFilePath = await _cloudinaryService.FileCreateAsync(dto.Image);

            existSlider.ImagePath = newFilePath;
        }

        _repository.Update(existSlider);
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



    private Func<IQueryable<Slider>, IIncludableQueryable<Slider, object>> _getIncludeFunc(Languages language)
    {

        return x => x.Include(x => x.SliderDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
    }
}

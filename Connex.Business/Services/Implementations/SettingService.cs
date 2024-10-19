using AutoMapper;
using Connex.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Connex.Business.Services.Implementations;

public class SettingService : ISettingService
{
    private readonly ISettingRepository _repository;
    private readonly IMapper _mapper;

    public SettingService(ISettingRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(SettingCreateDto dto, ModelStateDictionary ModelState)
    {
        if (ModelState.IsValid)
            return false;

        var isExist = await _repository.IsExistAsync(x => x.Key == dto.Key);

        if (isExist)
        {
            ModelState.AddModelError("Key", "Bu açar söz artıq mövcuddur.");
            return false;
        }

        var setting = _mapper.Map<Setting>(dto);

        await _repository.CreateAsync(setting);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var setting = await _repository.GetAsync(id);


        if (setting is null)
            throw new NotFoundException($"{id}-bu idli məlumat mövcud deyildir.");

        _repository.Delete(setting);
        await _repository.SaveChangesAsync();

    }

    public async Task<List<SettingGetDto>> GetAllAsync()
    {
        var settigs = await _repository.GetAll().ToListAsync();

        var dtos = _mapper.Map<List<SettingGetDto>>(settigs);

        return dtos;
    }

    public async Task<Dictionary<string, string>> GetAllWithDictionaryAsync()
    {
        var settings = await _repository.GetAll().ToDictionaryAsync(x => x.Key, x => x.Value);

        return settings;
    }

    public async Task<SettingGetDto> GetAsync(int id)
    {
        var setting = await _repository.GetAsync(id);

        if (setting is null)
            throw new NotFoundException($"{id}-bu idli məlumat mövcud deyildir.");

        var dto = _mapper.Map<SettingGetDto>(setting);

        return dto;
    }

    public async Task<SettingUpdateDto> GetUpdatedSettingAsync(int id)
    {
        var setting = await _repository.GetAsync(id);

        if (setting is null)
            throw new NotFoundException($"{id}-bu idli məlumat mövcud deyildir.");

        var dto = _mapper.Map<SettingUpdateDto>(setting);

        return dto;
    }

    public async Task<bool> UpdateAsync(SettingUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existSetting = await _repository.GetAsync(dto.Id);

        if (existSetting is null)
            throw new NotFoundException($"{dto.Id}-bu idli məlumat mövcud deyildir.");

        existSetting.Value = dto.Value;

        _repository.Update(existSetting);
        await _repository.SaveChangesAsync();

        return true;
    }
}

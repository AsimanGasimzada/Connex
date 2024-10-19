﻿namespace Connex.Business.Services.Abstractions;

public interface IService<TCreateDto, TUpdateDto>
    where TCreateDto : IDto
    where TUpdateDto : IDto
{
    Task<bool> CreateAsync(TCreateDto dto, ModelStateDictionary ModelState);
    Task<bool> UpdateAsync(TUpdateDto dto, ModelStateDictionary ModelState);
    Task<TUpdateDto> GetUpdatedDtoAsync(int id);
    Task DeleteAsync(int id);
}

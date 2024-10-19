using AutoMapper;
using Connex.Business.Extensions;
using Connex.Core.Enums;
using Microsoft.EntityFrameworkCore.Query;
using Microsoft.EntityFrameworkCore;

namespace Connex.Business.Services.Implementations;

public class ProjectService : IProjectService
{
    private readonly IProjectRepository _repository;
    private readonly ICloudinaryService _cloudinaryService;
    private readonly IMapper _mapper;

    public ProjectService(IProjectRepository repository, ICloudinaryService cloudinaryService, IMapper mapper)
    {
        _repository = repository;
        _cloudinaryService = cloudinaryService;
        _mapper = mapper;
    }

    public async Task<bool> CreateAsync(ProjectCreateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        if (!dto.Image.ValidateSize(2))
        {
            ModelState.AddModelError("Image", "Şəklin ölçüsü 2-mb dan artıq ola bilməz");
            return false;
        }
        if (!dto.Image.ValidateType())
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
            return false;
        }


        foreach (var detail in dto.ProjectDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.ProjectDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        var project = _mapper.Map<Project>(dto);

        var imagePath = await _cloudinaryService.FileCreateAsync(dto.Image);

        project.ImagePath = imagePath;

        await _repository.CreateAsync(project);
        await _repository.SaveChangesAsync();

        return true;
    }

    public async Task DeleteAsync(int id)
    {
        var project = await _repository.GetAsync(id);

        if (project is null)
            throw new NotFoundException($"{id}-bu id-də layihə tapılmadı!");

        _repository.Delete(project);
        await _repository.SaveChangesAsync();
    }

    public async Task<List<ProjectGetDto>> GetAllAsync(Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var projects = await _repository.GetAll(_getIncludeFunc(language)).ToListAsync();

        var dtos = _mapper.Map<List<ProjectGetDto>>(projects);

        return dtos;
    }

    public async Task<ProjectGetDto> GetAsync(int id, Languages language = Languages.Azerbaijan)
    {
        _checkLanguageId(ref language);

        var project = await _repository.GetAsync(id, _getIncludeFunc(language));

        if (project is null)
            throw new NotFoundException($"{id}-bu id-də layihə tapılmadı!");

        var dto = _mapper.Map<ProjectGetDto>(project);

        return dto;
    }

    public async Task<ProjectUpdateDto> GetUpdatedDtoAsync(int id)
    {
        var project = await _repository.GetAsync(id, x => x.Include(x => x.ProjectDetails));

        if (project is null)
            throw new NotFoundException($"{id}-bu id-də layihə tapılmadı!");

        var dto = _mapper.Map<ProjectUpdateDto>(project);

        return dto;
    }

    public async Task<bool> UpdateAsync(ProjectUpdateDto dto, ModelStateDictionary ModelState)
    {
        if (!ModelState.IsValid)
            return false;

        var existProject = await _repository.GetAsync(dto.Id, x => x.Include(x => x.ProjectDetails));

        if (existProject is null)
            throw new NotFoundException($"{dto.Id}-bu id-də layihə tapılmadı!");

        if (!dto.Image?.ValidateSize(2) ?? false)
        {
            ModelState.AddModelError("Image", "Şəklin ölçüsü 2-mb dan artıq ola bilməz");
            return false;
        }
        if (!dto.Image?.ValidateType() ?? false)
        {
            ModelState.AddModelError("Image", "Yalnız şəkil formatında dəyər daxil edə bilərsiniz");
            return false;
        }


        foreach (var detail in dto.ProjectDetails)
        {
            var isExistLanguage = _checkLanguageId(detail.LanguageId);

            if (!isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }

            isExistLanguage = dto.ProjectDetails.Any(x => x.LanguageId == detail.LanguageId && x != detail);

            if (isExistLanguage)
            {
                ModelState.AddModelError("", "Nə isə yanlış oldu, yenidən sınayın");
                return false;
            }
        }

        existProject = _mapper.Map(dto, existProject);

        if (dto.Image is { })
        {
            string newImagePath = await _cloudinaryService.FileCreateAsync(dto.Image);
            await _cloudinaryService.FileDeleteAsync(existProject.ImagePath);

            existProject.ImagePath = newImagePath;
        }

        _repository.Update(existProject);
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



    private Func<IQueryable<Project>, IIncludableQueryable<Project, object>> _getIncludeFunc(Languages language)
    {

        return x => x.Include(x => x.ProjectDetails.Where(x => x.LanguageId == (int)language)).ThenInclude(x => x.Language);
    }
}

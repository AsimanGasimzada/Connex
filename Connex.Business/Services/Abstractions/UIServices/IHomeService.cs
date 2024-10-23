using Connex.Core.Enums;

namespace Connex.Business.Services.Abstractions;

public interface IHomeService
{
    Task<HomeDto> GetHomeDtoAsync(Languages language = Languages.Azerbaijan);
}

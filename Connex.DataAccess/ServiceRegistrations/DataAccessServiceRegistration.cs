using Connex.DataAccess.Contexts;
using Connex.DataAccess.Repositories.Abstractions;
using Connex.DataAccess.Repositories.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connex.DataAccess.ServiceRegistrations;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));

        _addRepositories(services);

        return services;
    }

    private static void _addRepositories(IServiceCollection services)
    {
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<ISettingRepository, SettingRepository>();
    }
}

using Connex.Business.Services.Abstractions;
using Connex.Business.Services.Implementations;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Connex.Business.ServiceRegistrations;

public static class BusinessServiceRegistration
{
    public static IServiceCollection AddBusinessServices(this IServiceCollection services)
    {
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        _addServices(services);

        return services;
    }

    private static void _addServices(IServiceCollection services)
    {
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<ICloudinaryService,CloudinaryService>();
    }
}

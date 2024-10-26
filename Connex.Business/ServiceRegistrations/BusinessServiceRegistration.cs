using Connex.Business.Services.Implementations;
using Microsoft.AspNetCore.Mvc.Infrastructure;
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
        services.AddScoped<IAboutService, AboutService>();
        services.AddScoped<ICertificateService, CertificateService>();
        services.AddScoped<IPartnerService, PartnerService>();
        services.AddScoped<ISliderService, SliderService>();
        services.AddScoped<ISettingService, SettingService>();
        services.AddScoped<IServiceService, ServiceService>();
        services.AddScoped<ISubscriberService, SubscriberService>();
        services.AddScoped<ICloudinaryService, CloudinaryService>();
        services.AddScoped<IEmailService, EmailService>();
        services.AddScoped<IAccountService, AccountService>();
        services.AddScoped<IProjectService, ProjectService>();
        services.AddScoped<ILanguageService, LanguageService>();
        services.AddScoped<IFeatureService, FeatureService>();

        services.AddScoped<IHomeService, HomeService>();
        services.AddScoped<IContactService, ContactService>();

        services.AddSingleton<IActionContextAccessor, ActionContextAccessor>();
        services.AddHttpContextAccessor();
    }
}

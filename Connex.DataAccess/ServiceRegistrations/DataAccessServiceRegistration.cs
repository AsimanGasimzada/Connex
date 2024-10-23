using Connex.DataAccess.Contexts;
using Connex.DataAccess.DataInitalizers;
using Connex.DataAccess.Helpers;
using Connex.DataAccess.Repositories.Abstractions;
using Connex.DataAccess.Repositories.Implementations;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Connex.DataAccess.ServiceRegistrations;

public static class DataAccessServiceRegistration
{
    public static IServiceCollection AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddDbContext<AppDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("Default")));


        _addIdentity(services);
        _addRepositories(services);

        services.AddScoped<DbContextInitalizer>();

        return services;
    }

    private static void _addIdentity(IServiceCollection services)
    {
        services.AddIdentity<AppUser, IdentityRole>(options =>
        {
            options.Password.RequiredLength = 6;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.User.RequireUniqueEmail = true;
            options.SignIn.RequireConfirmedEmail = true;
            options.Lockout.AllowedForNewUsers = false;
            options.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            options.Lockout.MaxFailedAccessAttempts = 3;

        }).AddEntityFrameworkStores<AppDbContext>()
          .AddDefaultTokenProviders()
          .AddErrorDescriber<CustomIdentityErrorDescriber>();
    }

    private static void _addRepositories(IServiceCollection services)
    {

        services.AddScoped<IAboutRepository, AboutRepository>();
        services.AddScoped<ICertificateRepository, CertificateRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<ISliderRepository, SliderRepository>();
        services.AddScoped<ISettingRepository, SettingRepository>();
        services.AddScoped<IServiceRepository, ServiceRepository>();
        services.AddScoped<ISubscriberRepository, SubscriberRepository>();
        services.AddScoped<ILanguageRepository, LanguageRepository>();
        services.AddScoped<IPartnerRepository, PartnerRepository>();
        services.AddScoped<IProjectRepository, ProjectRepository>();
    }

}

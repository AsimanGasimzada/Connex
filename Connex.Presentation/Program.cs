using Connex.Business.ServiceRegistrations;
using Connex.DataAccess.ServiceRegistrations;
using Connex.Presentation.Extensions;

namespace Connex.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container
        builder.Services.AddControllersWithViews();

        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddBusinessServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error"); // Default error handler for MVC
            app.UseHsts();
        }

        await app.InitDatabaseAsync();

        // Register global exception handler middleware
        app.UseMiddleware<GlobalExceptionHandler>();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "areas",
            pattern: "{area:exists}/{controller=Dashboard}/{action=Index}/{id?}");

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }

}

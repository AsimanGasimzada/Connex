using Connex.DataAccess.ServiceRegistrations;
using Connex.Business.ServiceRegistrations;
using Connex.DataAccess.DataInitalizers;
using Connex.Presentation.Extensions;

namespace Connex.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();

        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddBusinessServices();


        var app = builder.Build();

        await app.InitDatabaseAsync();

        if (!app.Environment.IsDevelopment())
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthorization();

        app.MapControllerRoute(
            name: "default",
            pattern: "{controller=Home}/{action=Index}/{id?}");

        await app.RunAsync();
    }

    
}

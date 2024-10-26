using Connex.Business.ServiceRegistrations;
using Connex.DataAccess.ServiceRegistrations;
using Connex.Presentation.Extensions;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace Connex.Presentation;

public class Program
{
    public static async Task Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddControllersWithViews();
        builder.Services.ConfigureApplicationCookie(c =>
        {
            c.LoginPath = $"/Admin/Account/Login/{c.ReturnUrlParameter}";
        });

        builder.Services.AddDataAccessServices(builder.Configuration);
        builder.Services.AddBusinessServices();

        var app = builder.Build();

        if (app.Environment.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }
        else
        {
            app.UseExceptionHandler("/Home/Error");
            app.UseHsts();
        }


        await app.InitDatabaseAsync();

        //app.UseMiddleware<GlobalExceptionHandler>();

        app.UseHttpsRedirection();
        app.UseStaticFiles();

        app.UseRouting();

        app.UseAuthentication();
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

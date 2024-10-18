using Connex.DataAccess.DataInitalizers;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Connex.DataAccess.Contexts;

public class AppDbContext : IdentityDbContext<AppUser>
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        modelBuilder.AddSeedData();
    }

    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<SliderDetail> SliderDetails { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Partner> Partners { get; set; } = null!;
}

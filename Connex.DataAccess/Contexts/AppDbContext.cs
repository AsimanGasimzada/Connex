using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Connex.DataAccess.Contexts;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {

    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }


    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
}

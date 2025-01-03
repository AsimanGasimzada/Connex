﻿using Connex.DataAccess.DataInitalizers;
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


    public DbSet<About> Abouts { get; set; } = null!;
    public DbSet<AboutDetail> AboutDetails { get; set; } = null!;
    public DbSet<Certificate> Certificates { get; set; } = null!;
    public DbSet<Feature> Features { get; set; } = null!;
    public DbSet<FeatureDetail> FeatureDetails { get; set; } = null!;
    public DbSet<Language> Languages { get; set; } = null!;
    public DbSet<Partner> Partners { get; set; } = null!;
    public DbSet<Project> Projects { get; set; } = null!;
    public DbSet<ProjectDetail> ProjectDetails { get; set; } = null!;
    public DbSet<Setting> Settings { get; set; } = null!;
    public DbSet<Subscriber> Subscribers { get; set; } = null!;
    public DbSet<Slider> Sliders { get; set; } = null!;
    public DbSet<SliderDetail> SliderDetails { get; set; } = null!;
    public DbSet<Service> Services { get; set; } = null!;
    public DbSet<ServiceDetail> ServiceDetails { get; set; } = null!;
}

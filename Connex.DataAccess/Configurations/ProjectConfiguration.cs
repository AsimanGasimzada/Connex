using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class ProjectConfiguration : IEntityTypeConfiguration<Project>
{
    public void Configure(EntityTypeBuilder<Project> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(256);
        builder.Property(x => x.FilePath).IsRequired().HasMaxLength(256);
    }
}


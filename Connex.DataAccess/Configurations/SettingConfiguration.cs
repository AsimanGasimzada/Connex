using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class SettingConfiguration : IEntityTypeConfiguration<Setting>
{
    public void Configure(EntityTypeBuilder<Setting> builder)
    {
        builder.HasIndex(x => x.Key).IsUnique();

        builder.Property(x=>x.Key).IsRequired().HasMaxLength(32);
        builder.Property(x=>x.Value).IsRequired().HasMaxLength(256);
    }
}
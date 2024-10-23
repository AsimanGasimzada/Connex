using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class FeatureDetailConfiguration : IEntityTypeConfiguration<FeatureDetail>
{
    public void Configure(EntityTypeBuilder<FeatureDetail> builder)
    {
        builder.Property(x => x.Name).IsRequired().HasMaxLength(64);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(1024);

        builder.HasIndex(x => new { x.LanguageId, x.FeatureId }).IsUnique();
    }
}

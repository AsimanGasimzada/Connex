using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class SliderDetailConfiguration : IEntityTypeConfiguration<SliderDetail>
{
    public void Configure(EntityTypeBuilder<SliderDetail> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Subtitle).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(512);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(512);

        builder.HasIndex(x => new { x.LanguageId, x.SliderId }).IsUnique();
    }
}
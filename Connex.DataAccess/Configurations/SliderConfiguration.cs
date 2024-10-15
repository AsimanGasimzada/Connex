using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class SliderConfiguration : IEntityTypeConfiguration<Slider>
{
    public void Configure(EntityTypeBuilder<Slider> builder)
    {
        builder.Property(x => x.Title).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Subtitle).IsRequired().HasMaxLength(32);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(512);
        builder.Property(x => x.Description).IsRequired().HasMaxLength(512);
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(1024);

    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class LanguageConfiguration : IEntityTypeConfiguration<Language>
{
    public void Configure(EntityTypeBuilder<Language> builder)
    {
        builder.Property(x => x.Code).IsRequired().HasMaxLength(5);
        builder.Property(x => x.ImagePath).IsRequired();
        builder.Property(x => x.IsDefault).HasDefaultValue(false);

        builder.HasIndex(x => x.Code).IsUnique();
    }
}

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class SubscriberConfiguration : IEntityTypeConfiguration<Subscriber>
{
    public void Configure(EntityTypeBuilder<Subscriber> builder)
    {
        builder.Property(x=>x.EmailAddress).IsRequired().HasMaxLength(256);

        builder.HasIndex(x => x.EmailAddress).IsUnique();
    }
}

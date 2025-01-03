﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Connex.DataAccess.Configurations;

public class AboutConfiguration : IEntityTypeConfiguration<About>
{
    public void Configure(EntityTypeBuilder<About> builder)
    {
        builder.Property(x => x.ImagePath).IsRequired().HasMaxLength(256);
        builder.Property(x => x.BGImagePath).IsRequired().HasMaxLength(256);
        builder.Property(x => x.OrderNo).IsRequired();
    }
}

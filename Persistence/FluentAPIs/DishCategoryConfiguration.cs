using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentAPIs
{
    public class DishCategoryConfiguration : IEntityTypeConfiguration<DishCategory>
    {
        public void Configure(EntityTypeBuilder<DishCategory> builder)
        {
            builder.ToTable("DishCategory");
            builder.HasKey(x => x.Id).HasName("DishCategoryId");
            builder.Property(x => x.Name).IsRequired().HasDefaultValue(null).HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasDefaultValue(null).HasMaxLength(255);
            builder.Property(x => x.Image).IsRequired().HasDefaultValue(null).HasMaxLength(255);
            builder.Property(x => x.isActived).IsRequired().HasDefaultValue(1);

            builder.HasMany(x => x.Dishes)
                .WithOne(x => x.DishCategory)
                .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

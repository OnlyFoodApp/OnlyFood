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
    public class DishConfiguration : IEntityTypeConfiguration<Dish>
    {
        public void Configure(EntityTypeBuilder<Dish> builder)
        {
            builder.ToTable("Dish");
            builder.HasKey(x => x.Id).HasName("DishId");
            builder.Property(x => x.MenuId).IsRequired();
            builder.Property(x => x.DishCategoryId).IsRequired();
            builder.Property(x => x.DishName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Price).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.DishImage).IsRequired().HasMaxLength(255);
            builder.Property(x => x.DishIngredients).IsRequired().HasMaxLength(255);

            builder.HasOne(x => x.DishCategory)
                .WithMany(x => x.Dishes)
                .HasForeignKey(x => x.DishCategoryId);

            builder.HasOne(x => x.Menu)
                .WithMany(x => x.Dishes)
                .HasForeignKey(x => x.MenuId);

            builder.HasMany(x => x.OrderDetails)
                .WithOne(x => x.Dish)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

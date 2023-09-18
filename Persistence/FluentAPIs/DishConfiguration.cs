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
            //builder.ToTable("Dish");
            //builder.HasKey(x => x.Id);
            //builder.HasOne(c => c.DishCategory)
            //    .WithMany(a => a.Dishes)
            //    .OnDelete(DeleteBehavior.Cascade);


            //builder.HasMany(c => c.OrderDetails)
            //    .WithOne(a => a.Dish)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

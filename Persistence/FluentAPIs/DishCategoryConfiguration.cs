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
            //builder.ToTable("DishCategory");
            //builder.HasKey(x => x.Id);
            //builder.HasMany(c => c.Dishes)
            //    .WithOne(a => a.DishCategory)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

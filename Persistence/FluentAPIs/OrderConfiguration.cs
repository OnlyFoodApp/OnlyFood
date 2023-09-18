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
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            //builder.ToTable("Order");
            //builder.HasKey(x => x.Id);
            //builder.HasMany(c => c.OrdersDetails)
            //    .WithOne(a => a.Order)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

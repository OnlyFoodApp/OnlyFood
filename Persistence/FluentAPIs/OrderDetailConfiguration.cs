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
    public class OrderDetailConfiguration : IEntityTypeConfiguration<OrderDetail>
    {
        public void Configure(EntityTypeBuilder<OrderDetail> builder)
        {
            builder.ToTable("OrderDetail");
            builder.HasKey(x => x.Id).HasName("OrderDetailId");
            builder.Property(x => x.OrderId).IsRequired();
            builder.Property(x => x.DishId).IsRequired();
            builder.Property(x => x.Quantity).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.UnitPrice).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsCancelled).IsRequired().HasDefaultValue(0);
            builder.HasOne(x => x.Dish)
                .WithMany(x => x.OrderDetails)
                .HasForeignKey(x => x.DishId)
                .OnDelete(DeleteBehavior.Restrict);


            builder.HasOne(x => x.Order)
                .WithMany(x => x.OrdersDetails)
                .HasForeignKey(x => x.OrderId)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}

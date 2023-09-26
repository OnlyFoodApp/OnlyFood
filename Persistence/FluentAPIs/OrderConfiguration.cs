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
            builder.ToTable("Order");
            builder.HasKey(x => x.Id).HasName("OrderId");
            builder.Property(x => x.OrderDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.CustomerId).IsRequired();
            builder.Property(x => x.PaymentId).IsRequired();
            builder.Property(x => x.ExpectedDeliveryTime).IsRequired().HasDefaultValue(null);
            builder.Property(x => x.TotalAmount).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.NumberOfItems).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Discount).IsRequired().HasDefaultValue(0);
            builder.HasOne(x => x.Payment)
                .WithMany(x => x.Orders)
                .HasForeignKey(x => x.PaymentId);

            builder.HasMany(x => x.OrdersDetails)
                .WithOne(x => x.Order)
                .OnDelete(DeleteBehavior.Cascade);  
        }
    }
}

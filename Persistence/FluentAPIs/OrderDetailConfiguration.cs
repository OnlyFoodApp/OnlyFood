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
            //builder.ToTable("OrderDetail");
            //builder.HasKey(x => x.Id);
            //builder.HasOne(a => a.Order)
            //    .WithMany(o => o.OrdersDetails)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

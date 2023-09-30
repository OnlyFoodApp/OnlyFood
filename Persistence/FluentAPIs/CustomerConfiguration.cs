using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentAPIs
{
    public class CustomerConfiguration : IEntityTypeConfiguration<Customer>
    {
        public void Configure(EntityTypeBuilder<Customer> builder)
        {
            builder.ToTable("Customer");
            //builder.HasKey(x => x.AccountId).HasName("CustomerId");
            builder.Property(x => x.Address).IsRequired().HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.RewardsPoints).HasDefaultValue(0);

            builder.HasMany(x => x.Orders)
                .WithOne(x => x.Customer)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Account>(x => x.Account)
            //    .WithOne(x => x.Customer)
            //    .OnDelete(DeleteBehavior.Restrict) // Change to ON DELETE NO ACTION
            //    .HasForeignKey<Customer>(x => x.AccountId);
            //.HasConstraintName("FK_Customer_Account_AccountId");
        }
    }
}

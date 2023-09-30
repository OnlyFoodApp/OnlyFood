using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentAPIs
{
    public class AccountConfiguration : IEntityTypeConfiguration<Account>
    {
        public void Configure(EntityTypeBuilder<Account> builder)
        {
            builder.ToTable("Account");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Username).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Password).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Email).HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.FirstName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.LastName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.ProfilePicture).HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.Bio).HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.PhoneNumber).HasMaxLength(10).HasDefaultValue(null);
            builder.Property(x => x.ActiveStatus).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.Roles).HasMaxLength(255).HasDefaultValue(null);

            builder.HasOne(x => x.Customer)
                .WithOne(x => x.Account)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey<Customer>(x => x.AccountId);
            //.HasConstraintName("FK_Customer_Account_AccountId");

            builder.HasOne(x => x.Chef)
                    .WithOne(x => x.Account)
                    .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey<Chef>(x => x.AccountId);
            //.HasConstraintName("FK_Chef_Account_AccountId");
        }
    }
}

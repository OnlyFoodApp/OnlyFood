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
            //builder.ToTable("Account");
            //builder.HasKey(x => x.Id);
            //builder.HasOne(c => c.Customer)
            //    .WithOne(a => a.Account)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne(c => c.Chef)
            //    .WithOne(a => a.Account)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }
}

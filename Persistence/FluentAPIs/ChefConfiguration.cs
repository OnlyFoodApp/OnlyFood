using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentAPIs
{
    public class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            builder.ToTable("Chef");
            //builder.HasKey(x => x.AccountId).HasName("AccountId");
            builder.Property(x => x.Experience).IsRequired().HasDefaultValue(null).HasMaxLength(255);

            builder.HasMany(x => x.Certifications)
                .WithOne(x => x.Chef)
                .OnDelete(DeleteBehavior.Cascade);

            builder.HasMany(x => x.Campaigns)
                .WithOne(x => x.Chef)
                .OnDelete(DeleteBehavior.Cascade);

            //builder.HasOne<Account>(x => x.Account)
            //    .WithOne(x => x.Chef)
            //    .HasForeignKey<Chef>(x => x.AccountId)
            //    .OnDelete(DeleteBehavior.Restrict);
            //.HasConstraintName("FK_Chef_Account_AccountId");
        }

    }

}

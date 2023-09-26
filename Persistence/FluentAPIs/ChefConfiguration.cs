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

            //builder.HasOne(x => x.Account)
            //    .WithOne(x => x.Chef)
            //    .OnDelete(DeleteBehavior.Restrict) // Change to ON DELETE NO ACTION
            //    .HasConstraintName("FK_Chef_Account_AccountId");
        }

    }

}

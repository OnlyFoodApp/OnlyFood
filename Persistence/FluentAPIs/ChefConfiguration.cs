using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentAPIs
{
    public class ChefConfiguration : IEntityTypeConfiguration<Chef>
    {
        public void Configure(EntityTypeBuilder<Chef> builder)
        {
            //builder.ToTable("Chef");
            //builder.HasKey(x => x.AccountId);
            //builder.HasMany(c => c.Certifications)
            //    .WithOne(a => a.Chef)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasMany(c => c.Campaigns)
            //    .WithOne(a => a.Chef)
            //    .OnDelete(DeleteBehavior.Cascade);
        }
    }

}

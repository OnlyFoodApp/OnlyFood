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
    public class MenuConfiguration : IEntityTypeConfiguration<Menu>
    {
        public void Configure(EntityTypeBuilder<Menu> builder)
        {
            builder.ToTable("Menu");
            //builder.HasKey(x => x.Id).HasName("Id");
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsEdited).IsRequired().HasDefaultValue(0);

            builder.HasMany(x => x.Dishes)
                .WithOne(x => x.Menu)
                .OnDelete(DeleteBehavior.Cascade);


            //builder.HasOne(x => x.Campaign)
            //    .WithOne(x => x.Menu)
            //    .HasForeignKey<Menu>(x => x.CampaignId)
            //    .HasConstraintName("FK_Menu_Campaign_CampaignId");
        }
    }
}

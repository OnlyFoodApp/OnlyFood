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
    public class CampaignConfiguration : IEntityTypeConfiguration<Campaign>
    {
        public void Configure(EntityTypeBuilder<Campaign> builder)
        {
            builder.ToTable("Campaign");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.ChefID).IsRequired();
            builder.Property(x => x.CampaignName).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Description).IsRequired().HasMaxLength(255);
            builder.Property(x => x.StartDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.EndDate).IsRequired().HasDefaultValue(null);
            builder.Property(x => x.Status).IsRequired().HasDefaultValue(0);
            builder.HasOne(x => x.Chef)
                .WithMany(x => x.Campaigns)
                .HasForeignKey(x => x.ChefID);

            builder.HasOne(x => x.Menu)
                .WithOne(x => x.Campaign)
                .OnDelete(DeleteBehavior.Restrict)
                .HasForeignKey<Menu>(x => x.Id)
                .HasConstraintName("FK_Menu_Campaign_CampaignId");

        }
    }
}

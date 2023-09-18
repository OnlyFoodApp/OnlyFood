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
            //builder.ToTable("Menu");
            //builder.HasKey(x => x.CampaignId);
            //builder.HasMany(c => c.Dishes)
            //    .WithOne(a => a.Menu)
            //    .OnDelete(DeleteBehavior.Cascade);

            //builder.HasKey(x => x.CampaignId);
            //builder.HasOne(c => c.Campaign)
            //    .WithOne(a => a.Menu)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

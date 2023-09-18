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
            //builder.ToTable("Campaign");
            //builder.HasKey(x => x.Id);
            //builder.HasOne(c => c.Menu)
            //    .WithOne(a => a.Campaign)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

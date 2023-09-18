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
    public class CertificateConfiguration : IEntityTypeConfiguration<Certification>
    {
        public void Configure(EntityTypeBuilder<Certification> builder)
        {
            //builder.ToTable("Certification");
            //builder.HasKey(x => x.Id);
            //builder.HasOne(c => c.)
            //    .WithMany(a => a.Account)
            //    .OnDelete(DeleteBehavior.Cascade);

        }
    }
}

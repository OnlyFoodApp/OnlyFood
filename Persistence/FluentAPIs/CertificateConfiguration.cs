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
            builder.ToTable("Certification");
            builder.HasKey(x => x.Id).HasName("CertificationId");
            builder.Property(x => x.Name).IsRequired().HasDefaultValue(null).HasMaxLength(255);
            builder.Property(x => x.CertificationDescription).IsRequired().HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.EffectiveDate).IsRequired().HasDefaultValue(null);
            builder.Property(x => x.ExpirationDate).IsRequired().HasDefaultValue(null);
            builder.Property(x => x.IssuingAuthority).IsRequired().HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.CertificationURL).IsRequired().HasMaxLength(255).HasDefaultValue(null);
            builder.Property(x => x.IsValid).IsRequired().HasDefaultValue(0);
            builder.HasOne(x => x.Chef)
                .WithMany(x => x.Certifications)
                .HasForeignKey(x => x.ChefID);

        }
    }
}

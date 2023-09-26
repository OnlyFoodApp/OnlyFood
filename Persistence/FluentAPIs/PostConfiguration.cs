using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistence.FluentAPIs
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.ToTable("Post");
            builder.HasKey(x => x.Id).HasName("PostId");
            builder.Property(x => x.Title).IsRequired().HasMaxLength(255);
            builder.Property(x => x.Content).IsRequired().HasMaxLength(255);
            builder.Property(x => x.MediaURLs).IsRequired().HasMaxLength(255);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.IsEdited).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.DisplayIndex).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.AccountID).IsRequired();
            builder.HasOne(x => x.Account)
                .WithMany(x => x.Posts)
                .HasForeignKey(x => x.AccountID);

            builder.HasMany(x => x.Likes)
                .WithOne(x => x.Post)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}

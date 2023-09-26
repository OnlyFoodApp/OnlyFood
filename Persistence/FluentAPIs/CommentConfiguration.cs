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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.ToTable("Comment");
            builder.HasKey(x => x.Id).HasName("CommentId");
            builder.Property(x => x.AccountId).IsRequired();
            builder.Property(x => x.ParentCommentId).IsRequired().HasDefaultValue(null);
            builder.Property(x => x.PostId).IsRequired();
            builder.Property(x => x.Text).IsRequired().HasDefaultValue(null).HasMaxLength(255);
            builder.Property(x => x.CreatedDate).IsRequired().HasDefaultValue(DateTime.Now);
            builder.Property(x => x.IsDeleted).IsRequired().HasDefaultValue(0);
            builder.Property(x => x.ISEdited).IsRequired().HasDefaultValue(0);
            builder.HasOne(x => x.Post)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.PostId)
                .OnDelete(DeleteBehavior.Restrict);
            builder.HasOne(x => x.Account)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.AccountId)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.ParentComment)
                .WithMany(x => x.ChildComments)
                .OnDelete(DeleteBehavior.Restrict) // Change to ON DELETE NO ACTION
                .HasConstraintName("FK_Comment_Comment_ParentCommentId");
        }
    }
}

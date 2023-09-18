using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Comment : BaseAuditableEntity
    {
        [Required]
        [ForeignKey("Account")]
        public Guid AccountId { get; set; }
        [Required]
        [ForeignKey("Post")]
        public Guid PostId { get; set; }
        public string Text { get; set; }
        [ForeignKey("Comment")]
        public Guid? ParentCommentId { get; set; }
        public virtual Comment ParentComment { get; set; }
        public virtual Post Post { get; set; }
        public virtual ICollection<Comment> ChildComments { get; set; } = new List<Comment>();
        [Required]
        public bool IsDeleted { get; set; }
    }
}

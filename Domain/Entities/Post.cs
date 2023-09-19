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
    public class Post : BaseAuditableEntity
    {
        [Required]
        private string Title { get; set; }
        private string Content { get; set; }
        [Required]
        [ForeignKey("Account")]
        public Guid AccountID { get; set; }
        public int? DisplayIndex { get; set; }
        [Required]
        public string MediaURLs { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
        public virtual ICollection<Comment> Comments { get; set; } = new List<Comment>();
        public virtual ICollection<Like> Likes { get; set; } = new List<Like>();


    }
}

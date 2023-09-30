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
        public string Title { get; set; }
        public string Content { get; set; }
        public Guid AccountID { get; set; }
        public int DisplayIndex { get; set; }
        public string MediaURLs { get; set; }
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }
        public Account Account { get; set; }
        public virtual ICollection<Comment>? Comments { get; set; }
        public virtual ICollection<Like>? Likes { get; set; }


    }
}

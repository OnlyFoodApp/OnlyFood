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
    public class Like : BaseAuditableEntity
    {
        [Required]
        [ForeignKey("Post")]
        public Guid PostId { get; set; }
        //[Required]
        //[ForeignKey("Account")]
        //public Guid AccountId { get; set; }
        [Required]
        public bool IsLiked { get; set; }
    }
}

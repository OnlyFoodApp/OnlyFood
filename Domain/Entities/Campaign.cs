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
    public class Campaign : BaseAuditableEntity
    {
        [Required]
        public string CampaignName { get; set;}
        public string? Description { get; set;}
        [Required]
        public DateTime StartDate { get; set;}
        public DateTime EndDate { get; set;}
        [Required]
        [ForeignKey("Chef")]
        public Guid ChefID { get; set;}
        public bool Status { get; set;}
        public virtual Menu Menu { get; set;}
        public virtual Chef Chef { get; set;}
        
    }
}

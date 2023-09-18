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
    public class Certification : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }
        [Required]
        [ForeignKey("Chef")]
        public Guid ChefID { get; set; }
        [Required]
        public string IssuingAuthority { get; set; }
        [Required]
        public string CertificationDescription { get; set; }
        [Required]
        public string EffectiveDate { get; set;}
        [Required]
        public string ExpirationDate { get; set;}
        [Required]
        public string CertificationURL { get; set;}
        public bool IsValid { get; set;}
        public virtual Chef Chef { get; set;}
    }
}

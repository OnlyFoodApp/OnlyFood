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
        public string Name { get; set; }
        public Guid ChefID { get; set; }
        public string IssuingAuthority { get; set; }
        public string CertificationDescription { get; set; }
        public string EffectiveDate { get; set;}
        public string ExpirationDate { get; set;}
        public string CertificationURL { get; set;}
        public byte IsValid { get; set;}
        public virtual Chef Chef { get; set;}
    }
}

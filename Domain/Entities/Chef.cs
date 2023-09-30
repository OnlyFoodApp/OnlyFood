using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace Domain.Entities
{
    public class Chef : BaseAuditableEntity
    {
        public string? Experience { get; set; }
        public string? Awards { get; set; }

        // Navigation Property
        public virtual Account? Account { get; set; }
        public Guid? AccountId { get; set; }
        public virtual ICollection<Campaign>? Campaigns { get; set; }
        public virtual ICollection<Certification>? Certifications { get; set; }


    }
}

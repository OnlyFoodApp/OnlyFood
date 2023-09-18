using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;

namespace Domain.Entities
{
    public class Payment : BaseAuditableEntity
    {
        [Required]
        public string Name { get; set; }
        public string? Description { get; set; }
        [Required]
        public bool IsActived { get; set; }

        // Navigation Property to represent the orders that use this payment method
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

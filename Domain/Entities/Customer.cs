using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities
{
    public class Customer : BaseAuditableEntityWithoutId
    {
        [Required]
        public string? Address { get; set; }
        public int RewardsPoints { get; set; }

        [Key]
        public Guid AccountId { get; set; }

        // Navigation Property
        public virtual Account Account { get; set; }
        public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
    }
}

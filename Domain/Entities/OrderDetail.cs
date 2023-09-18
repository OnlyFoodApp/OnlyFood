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
    public class OrderDetail : BaseAuditableEntity
    {
        [Required]
        public Guid OrderId { get; set; }
        [Required]

        public Guid DishId { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        public float UnitPrice { get; set; }
        public bool IsCancelled { get; set; }

    }
}

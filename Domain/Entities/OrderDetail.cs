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
        public Guid OrderId { get; set; }

        public Guid DishId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public byte IsCancelled { get; set; }

        public Order Order { get; set; }
        public Dish Dish { get; set; }

    }
}

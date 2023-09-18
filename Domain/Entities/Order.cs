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
    public class Order : BaseAuditableEntity
    {
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        [ForeignKey("Customer")]
        public Guid CustomerId { get; set; }
        [Required]
        [ForeignKey("Payment")]
        public Guid PaymentId { get; set; }
        [Required]
        public DateTime ExpectedDeliveryTime { get; set; }
        [Required]
        public float TotalAmount { get; set;}
        [Required] 
        public int NumberOfItems { get; set; }
        public float Discount { get; set;}
        // Navigation Property
        public virtual Customer Customer { get; set; }

        // Navigation Property to represent the payment method used for this order
        public virtual Payment Payment { get; set; }
        [ForeignKey("OrderDetail")]
        public virtual ICollection<OrderDetail> OrdersDetails { get; set; } = new List<OrderDetail>();

    }
}

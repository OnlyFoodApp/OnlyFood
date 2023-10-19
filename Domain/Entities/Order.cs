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
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
        public float TotalAmount { get; set;}
        public int NumberOfItems { get; set; }
        public float Discount { get; set;}
        public int Status { get; set; }
        // Navigation Property
        public virtual Customer Customer { get; set; }

        // Navigation Property to represent the payment method used for this order
        public virtual Payment? Payment { get; set; }
        public virtual ICollection<OrderDetail>? OrdersDetails { get; set; }

    }
}

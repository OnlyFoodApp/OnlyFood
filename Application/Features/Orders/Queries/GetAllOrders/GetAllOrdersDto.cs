using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Orders.Queries.GetAllOrders
{
    public class GetAllOrdersDto : IMapFrom<Order>
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public string CustomerName { get; set; }
        public Guid PaymentId { get; set; }
        public string PaymentName { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
        public float TotalAmount { get; set; }
        public int NumberOfItems { get; set; }
        public float Discount { get; set; }
        public int Status { get; set; }
    }
}

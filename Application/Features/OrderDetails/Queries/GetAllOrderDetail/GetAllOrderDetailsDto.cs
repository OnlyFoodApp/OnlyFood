using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderDetails.Queries.GetAllOrderDetail
{
    
    public class GetAllOrderDetailsDto : IMapFrom<OrderDetail>
    {
        
        public Guid Id { get; set; }
        public Guid DishId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public byte IsCancelled { get; set; }
    }
}

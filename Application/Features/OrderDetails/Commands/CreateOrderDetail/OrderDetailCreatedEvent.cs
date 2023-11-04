using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    
    public class OrderDetailCreatedEvent : BaseEvent
    {
        public OrderDetail OrderDetail { get; }

        public OrderDetailCreatedEvent(OrderDetail orderDetail)
        {
            OrderDetail = OrderDetail;
        }
    }
}

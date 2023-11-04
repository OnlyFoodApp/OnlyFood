using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.UpdateOrder
{
    
    public class OrderUpdatedEvent : BaseEvent
    {
        public Order Order { get; }

        public OrderUpdatedEvent(Order order)
        {
            Order = order;
        }
    }
}

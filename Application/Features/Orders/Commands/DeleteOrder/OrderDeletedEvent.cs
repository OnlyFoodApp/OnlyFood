using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Orders.Commands.DeleteOrder
{
    public class OrderDeletedEvent : BaseEvent
    {
        public Order Order { get; }

        public OrderDeletedEvent(Order order)
        {
            Order = order;
        }
    }
}

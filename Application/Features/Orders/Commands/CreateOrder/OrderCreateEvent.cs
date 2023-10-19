using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class OrderCreateEvent : BaseEvent
    {
        public Order Order { get; }

        public OrderCreateEvent(Order order)
        {
            Order = order;
        }
    }
}

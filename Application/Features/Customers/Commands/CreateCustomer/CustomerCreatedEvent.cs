using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Customers.Commands.CreateCustomer
{
    public class CustomerCreatedEvent : BaseEvent
    {
        public Customer Customer { get; }

        public CustomerCreatedEvent(Customer customer)
        {
            Customer = customer;
        }
    }
}

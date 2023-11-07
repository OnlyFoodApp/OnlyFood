using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Customers.Commands.UpdateCustomer
{
    public class CustomerUpdatedEvent : BaseEvent
    {
    public Customer Customer { get; }


    public CustomerUpdatedEvent(Customer customer)
    {
        Customer = customer;
    }
    }
}

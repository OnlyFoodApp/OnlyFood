using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Customers.Commands.DeleteCustomer
{
    public class CustomerDeletedEvent : BaseEvent
    {
    public Customer Customer { get; }


    public CustomerDeletedEvent(Customer customer)
    {
        Customer = customer;
    }
    }
}

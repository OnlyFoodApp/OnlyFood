using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Customers.Queries.GetCustomerById
{
    public class GetCustomerByIdDto : IMapFrom<Customer>, IMapFrom<Account>
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public int RewardsPoints { get; set; }
        //Account properties
        public Account Account { get; set; }
    }
}

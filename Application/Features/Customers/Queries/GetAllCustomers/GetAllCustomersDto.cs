using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersDto : IMapFrom<Customer>
    {
        public string? Address { get; set; }
        public int RewardsPoints { get; set; }
    }
}

using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersDto : IMapFrom<Customer>
    {
        public Guid Id { get; set; }
        public string? Address { get; set; }
        public int RewardsPoints { get; set; }
        //Account properties
        public Account Account { get; set; }
    }
}

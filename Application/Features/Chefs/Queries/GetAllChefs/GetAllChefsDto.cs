
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Chefs.Queries.GetAllChefs
{
    public class GetAllChefsDto : IMapFrom<Domain.Entities.Chef>
    {
        public Guid Id { get; set; }
        public string Experience { get; set; }
        public string? Awards { get; set; }

        public Account Account { get; set; }
        // Navigation Property
        //public virtual Account Account { get; set; }
    }
}

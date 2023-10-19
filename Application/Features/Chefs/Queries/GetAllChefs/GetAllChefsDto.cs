
using Application.Common.Mappings;

namespace Application.Features.Chefs.Queries.GetAllChefs
{
    public class GetAllChefsDto : IMapFrom<Domain.Entities.Chef>
    {
        public string Experience { get; set; }
        public string? Awards { get; set; }

        // Navigation Property
        //public virtual Account Account { get; set; }
    }
}

using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Chefs.Queries.GetChefWithId
{
    public class GetChefWithIdDto : IMapFrom<Account>, IMapFrom<Domain.Entities.Chef>
    {
        public Guid Id { get; set; }
        public string? Experience { get; set; }
        public string? Awards { get; set; }

        // Navigation Property
        public virtual Account Account { get; set; }
        public Guid AccountId { get; set; }
    }
}

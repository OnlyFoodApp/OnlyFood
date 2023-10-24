using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Likes.Queries
{
    
    public class GetAllLikesDto : IMapFrom<Like>
    {
        public Guid PostId { get; set; }

        public Guid AccountId { get; set; }

    }
}

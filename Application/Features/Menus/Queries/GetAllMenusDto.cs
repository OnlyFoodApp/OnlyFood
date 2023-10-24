using Application.Common.Mappings;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Menus.Queries
{
    public class GetAllMenusDto : IMapFrom<Menu>
    {
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }
        public Guid CampaignId { get; set; }

    }       
}

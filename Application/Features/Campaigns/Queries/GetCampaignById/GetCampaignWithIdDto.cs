using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Campaigns.Queries.GetCampaignById
{
    public class GetCampaignWithIdDto : IMapFrom<Campaign>
    {
        public string CampaignName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ChefID { get; set; }
        public byte Status { get; set; }
        public virtual Menu? Menu { get; set; }
        public virtual Domain.Entities.Chef Chef { get; set; }
    }
}

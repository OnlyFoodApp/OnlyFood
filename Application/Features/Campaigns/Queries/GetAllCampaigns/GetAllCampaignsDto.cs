using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Domain.Entities;

namespace Application.Features.Campaigns.Queries.GetAllCampaigns
{
    public class GetAllCampaignsDto : IMapFrom<Campaign>
    {
        public Guid Id { get; set; }
        public string CampaignName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ChefID { get; set; }

        public Domain.Entities.Chef Chef { get; set; }
        public byte Status { get; set; }
    }
}

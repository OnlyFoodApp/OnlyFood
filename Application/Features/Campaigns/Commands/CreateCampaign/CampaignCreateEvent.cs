using Domain.Common;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.CreateCampaign
{
    public class CampaignCreatedEvent : BaseEvent
    {
        public Campaign Campaign { get; }


        public CampaignCreatedEvent(Campaign Campaign)
        {
            Campaign = Campaign;
        }
    }
}

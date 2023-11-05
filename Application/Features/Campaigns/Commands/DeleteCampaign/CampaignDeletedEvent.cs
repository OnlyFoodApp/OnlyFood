using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Common;
using Domain.Entities;

namespace Application.Features.Campaigns.Commands.DeleteCampaign
{
    public class CampaignDeletedEvent : BaseEvent
    {
        public Campaign Campaign { get; }

        public CampaignDeletedEvent(Campaign campaign)
        {
            Campaign = campaign;
        }
    }
}

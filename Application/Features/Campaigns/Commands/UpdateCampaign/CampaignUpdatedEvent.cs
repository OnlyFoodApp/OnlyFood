using Domain.Common;
using Domain.Entities;


namespace Application.Features.Campaigns.Commands.UpdateCampaign
{
    public class CampaignUpdatedEvent : BaseEvent
    {
        public Campaign Campaign { get; }


        public CampaignUpdatedEvent(Campaign campaign)
        {
            Campaign = campaign;
        }
    }
}

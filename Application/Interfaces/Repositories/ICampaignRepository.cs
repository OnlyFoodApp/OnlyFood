using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Repositories
{
    public interface ICampaignRepository
    {
        Task<Campaign> GetCampaignByIdAsync(Guid campaignId);
    }
}

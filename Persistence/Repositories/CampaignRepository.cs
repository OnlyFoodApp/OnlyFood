using Application.Interfaces.Repositories;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class CampaignRepository : ICampaignRepository
    {
        private readonly IGenericRepository<Campaign> _repository;

        public CampaignRepository(IGenericRepository<Campaign> repository)
        {
            _repository = repository;
        }
        public async Task<Campaign> GetCampaignByIdAsync(Guid campaignId)
        {
            return await _repository.Entities.FirstOrDefaultAsync(x => x.Id == campaignId);
        }
    }
}

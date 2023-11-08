using Application.Features.Accounts.Queries.GetAllAccounts;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Campaigns.Queries.GetAllCampaigns
{
    public record GetAllCampaignsQuery : IRequest<Result<List<GetAllCampaignsDto>>>;

    internal class GetAllCampaignsQueryHandler : IRequestHandler<GetAllCampaignsQuery, Result<List<GetAllCampaignsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCampaignsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCampaignsDto>>> Handle(GetAllCampaignsQuery request, CancellationToken cancellationToken)
        {

            var campaigns = await _unitOfWork.Repository<Campaign>().Entities
                .ProjectTo<GetAllCampaignsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            foreach (var campaign in campaigns)
            {
                var chef = await _unitOfWork.Repository<Domain.Entities.Chef>().Entities.Where(c => c.Id == campaign.ChefID)
                .SingleOrDefaultAsync(cancellationToken);
                if (chef != null)
                {
                    var  account = await _unitOfWork.Repository<Account>().Entities.Where(a => a.Id == chef.AccountId)
                    .SingleOrDefaultAsync(cancellationToken);
                    if(account != null)
                    campaign.Username = account.Username;
                }
            }

            return await Result<List<GetAllCampaignsDto>>.SuccessAsync(campaigns);
        }
    }
}

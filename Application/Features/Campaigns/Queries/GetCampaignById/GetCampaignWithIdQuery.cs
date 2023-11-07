using Application.Features.Chefs.Queries.GetChefWithId;
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

namespace Application.Features.Campaigns.Queries.GetCampaignById
{
    public record GetCampaignWithIdQuery(Guid id) : IRequest<Result<GetCampaignWithIdDto>>;

    internal class GetCampaignWithIdQueryHandler : IRequestHandler<GetCampaignWithIdQuery, Result<GetCampaignWithIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCampaignWithIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCampaignWithIdDto>> Handle(GetCampaignWithIdQuery request, CancellationToken cancellationToken)
        {
            var campaign = await _unitOfWork.Repository<Campaign>().Entities.Where(a => a.Id.Equals(request.id))
                .ProjectTo<GetCampaignWithIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return await Result<GetCampaignWithIdDto>.SuccessAsync(campaign);
        }
    }
}

using Application.Features.Campaigns.Queries.GetAllCampaigns;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certifications.Queries
{
    public record GetAllCertificationsQuery : IRequest<Result<List<GetAllCertificationsDto>>>;

    internal class GetAllCertificationsQueryHandler : IRequestHandler<GetAllCertificationsQuery, Result<List<GetAllCertificationsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCertificationsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCertificationsDto>>> Handle(GetAllCertificationsQuery request, CancellationToken cancellationToken)
        {

            var certification = await _unitOfWork.Repository<Certification>().Entities
                .ProjectTo<GetAllCertificationsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllCertificationsDto>>.SuccessAsync(certification);
        }
    }
}

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

namespace Application.Features.Certifications.Queries.GetCertificationById
{
    public record GetCertificationWithIdQuery(Guid id) : IRequest<Result<GetCertificationWithIdDto>>;

    internal class GetCertificationWithIdQueryHandler : IRequestHandler<GetCertificationWithIdQuery, Result<GetCertificationWithIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCertificationWithIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetCertificationWithIdDto>> Handle(GetCertificationWithIdQuery request, CancellationToken cancellationToken)
        {
            var certification = await _unitOfWork.Repository<Certification>().Entities.Where(a => a.Id.Equals(request.id))
                .ProjectTo<GetCertificationWithIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            return await Result<GetCertificationWithIdDto>.SuccessAsync(certification);
        }
    }
}

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

namespace Application.Features.Chefs.Queries.GetChefWithId
{
    public record GetChefWithIdQuery(Guid id) : IRequest<Result<GetChefWithIdDto>>;

    internal class GetChefWithIdQueryHandler : IRequestHandler<GetChefWithIdQuery, Result<GetChefWithIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetChefWithIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetChefWithIdDto>> Handle(GetChefWithIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Repository<Account>().Entities.Where(a => a.Id.Equals(request.id))
                .ProjectTo<GetChefWithIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            var chef = await _unitOfWork.Repository<Domain.Entities.Chef>().Entities.Where(a => a.AccountId.Equals(request.id))
                .ProjectTo<GetChefWithIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);


            account.Awards = chef.Awards;
            account.Experience = chef.Experience;

            return await Result<GetChefWithIdDto>.SuccessAsync(account);
        }
    }
}

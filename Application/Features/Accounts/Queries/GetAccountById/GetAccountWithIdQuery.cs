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

namespace Application.Features.Accounts.Queries.GetAccountById
{
    public record GetAccountWithIdQuery(Guid id) : IRequest<Result<GetAccountWithIdDto>>;

    internal class GetAccountWithIdQueryHandler : IRequestHandler<GetAccountWithIdQuery, Result<GetAccountWithIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAccountWithIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetAccountWithIdDto>> Handle(GetAccountWithIdQuery request, CancellationToken cancellationToken)
        {
            var account = await _unitOfWork.Repository<Account>().Entities.Where(a => a.Id.Equals(request.id))
                .ProjectTo<GetAccountWithIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);

            //var Account = await _unitOfWork.Repository<Domain.Entities.Account>().Entities.Where(a => a.AccountId.Equals(request.id))
            //    .ProjectTo<GetAccountWithIdDto>(_mapper.ConfigurationProvider)
            //    .SingleOrDefaultAsync(cancellationToken);


            //account.Awards = Account.Awards;
            //account.Experience = Account.Experience;

            return await Result<GetAccountWithIdDto>.SuccessAsync(account);
        }
    }
}

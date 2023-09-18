using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Accounts.Queries.GetAllAccounts
{
    public record GetAllAccountsQuery : IRequest<Result<List<GetAllAccountsDto>>>;

    internal class GetAllAccountsQueryHandler : IRequestHandler<GetAllAccountsQuery, Result<List<GetAllAccountsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllAccountsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllAccountsDto>>> Handle(GetAllAccountsQuery request, CancellationToken cancellationToken)
        {
            var accounts = await _unitOfWork.Repository<Account>().Entities
                .ProjectTo<GetAllAccountsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllAccountsDto>>.SuccessAsync(accounts);
        }
    }
}

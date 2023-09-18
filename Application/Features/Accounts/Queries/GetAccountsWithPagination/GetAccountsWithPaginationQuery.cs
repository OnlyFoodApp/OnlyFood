using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Extensions;
using Application.Interfaces.Repositories;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Features.Accounts.Queries.GetAccountsWithPagination
{
    public class GetAccountsWithPaginationQuery : IRequest<PaginatedResult<GetAccountsWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAccountsWithPaginationQuery()
        {
        }

        public GetAccountsWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }


        internal class GetAccountsWithPaginationQueryHandler : IRequestHandler<GetAccountsWithPaginationQuery, PaginatedResult<GetAccountsWithPaginationDto>>
        {
            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public GetAccountsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
            {
                _unitOfWork = unitOfWork;
                _mapper = mapper;
            }

            public async Task<PaginatedResult<GetAccountsWithPaginationDto>> Handle(GetAccountsWithPaginationQuery query, CancellationToken cancellationToken)
            {
                return await _unitOfWork.Repository<Account>().Entities
                    .OrderBy(x => x.FirstName)
                    .ProjectTo<GetAccountsWithPaginationDto>(_mapper.ConfigurationProvider)
                    .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
            }
        }
    }
}

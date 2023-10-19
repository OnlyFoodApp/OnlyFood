using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Shared;
using Application.Extensions;
using AutoMapper.QueryableExtensions;

namespace Application.Features.Chefs.Queries.GetChefsWithPagination
{
    public class GetChefsWithPaginationQuery : IRequest<PaginatedResult<GetChefsWithPaginationDto>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetChefsWithPaginationQuery()
        {
        }

        public GetChefsWithPaginationQuery(int pageNumber, int pageSize)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
        }
    }

    internal class GetChefsWithPaginationQueryHandler : IRequestHandler<GetChefsWithPaginationQuery, PaginatedResult<GetChefsWithPaginationDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetChefsWithPaginationQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PaginatedResult<GetChefsWithPaginationDto>> Handle(GetChefsWithPaginationQuery query, CancellationToken cancellationToken)
        {
            return await _unitOfWork.Repository<Domain.Entities.Chef>().Entities
                .OrderBy(x => x.Account.FirstName)
                .ProjectTo<GetChefsWithPaginationDto>(_mapper.ConfigurationProvider)
                .ToPaginatedListAsync(query.PageNumber, query.PageSize, cancellationToken);
        }
    }
}

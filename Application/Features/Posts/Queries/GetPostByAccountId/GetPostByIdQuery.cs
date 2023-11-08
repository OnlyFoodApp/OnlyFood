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

namespace Application.Features.Posts.Queries.GetPostByAccountId
{
    public record GetPostByAccountIdQuery(Guid accountId) : IRequest<Result<List<GetPostByAccountIdDto>>>;

    internal class GetPostByAccountIdQueryHandler : IRequestHandler<GetPostByAccountIdQuery, Result<List<GetPostByAccountIdDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostByAccountIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetPostByAccountIdDto>>> Handle(GetPostByAccountIdQuery request, CancellationToken cancellationToken)
        {

            var posts = await _unitOfWork.Repository<Post>().Entities.Where(a => a.AccountID.Equals(request.accountId))
                .ProjectTo<GetPostByAccountIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return await Result<List<GetPostByAccountIdDto>>.SuccessAsync(posts);
        }
    }
}

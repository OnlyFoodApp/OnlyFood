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

namespace Application.Features.Posts.Queries.GetPostById
{
    public record GetPostByPostIdQuery(Guid id) : IRequest<Result<GetPostByIdDto>>;

    internal class GetPostByPostIdQueryHandler : IRequestHandler<GetPostByPostIdQuery, Result<GetPostByIdDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetPostByPostIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetPostByIdDto>> Handle(GetPostByPostIdQuery request, CancellationToken cancellationToken)
        {

            var post = await _unitOfWork.Repository<Post>().Entities.Where(a => a.Id.Equals(request.id))
                .ProjectTo<GetPostByIdDto>(_mapper.ConfigurationProvider)
                .SingleOrDefaultAsync(cancellationToken);


            return await Result<GetPostByIdDto>.SuccessAsync(post);
        }
    }
}

using Application.Features.Comments.Queries;
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

namespace Application.Features.Posts.Queries
{
    public record GetAllPostsQuery : IRequest<Result<List<GetAllPostsDto>>>;

    internal class GetAllPostsQueryHandler : IRequestHandler<GetAllPostsQuery, Result<List<GetAllPostsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllPostsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllPostsDto>>> Handle(GetAllPostsQuery request, CancellationToken cancellationToken)
        {
            var posts = await _unitOfWork.Repository<Post>().Entities
                .ProjectTo<GetAllPostsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);
            return await Result<List<GetAllPostsDto>>.SuccessAsync(posts);
        }
    }
}

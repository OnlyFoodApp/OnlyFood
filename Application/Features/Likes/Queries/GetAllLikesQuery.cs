using Application.Features.Dishs.Queries;
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

namespace Application.Features.Likes.Queries
{
    
    public record GetAllLikesQuery : IRequest<Result<List<GetAllLikesDto>>>;

    internal class GetAllLikesQueryHandler : IRequestHandler<GetAllLikesQuery, Result<List<GetAllLikesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllLikesQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllLikesDto>>> Handle(GetAllLikesQuery request, CancellationToken cancellationToken)
        {

            var like = await _unitOfWork.Repository<Like>().Entities
                .ProjectTo<GetAllLikesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllLikesDto>>.SuccessAsync(like);
        }
    }
}

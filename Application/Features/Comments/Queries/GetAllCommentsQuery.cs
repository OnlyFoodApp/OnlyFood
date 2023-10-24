using Application.Features.Certifications.Queries;
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

namespace Application.Features.Comments.Queries
{
    public record GetAllCommentsQuery : IRequest<Result<List<GetAllCommentsDto>>>;

    internal class GetAllCommentsQueryHandler : IRequestHandler<GetAllCommentsQuery, Result<List<GetAllCommentsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllCommentsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllCommentsDto>>> Handle(GetAllCommentsQuery request, CancellationToken cancellationToken)
        {

            var comments = await _unitOfWork.Repository<Comment>().Entities
                .ProjectTo<GetAllCommentsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllCommentsDto>>.SuccessAsync(comments);
        }
    }
}

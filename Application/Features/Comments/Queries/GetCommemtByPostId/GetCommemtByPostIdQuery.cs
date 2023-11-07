﻿using Application.Features.Accounts.Queries.GetAllAccounts;
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

namespace Application.Features.Chefs.Queries.GetCommemtByPostId
{
    public record GetCommemtByPostIdQuery(Guid id) : IRequest<Result<List<GetCommemtByPostIdDto>>>;

    internal class GetCommemtByPostIdQueryHandler : IRequestHandler<GetCommemtByPostIdQuery, Result<List<GetCommemtByPostIdDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCommemtByPostIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetCommemtByPostIdDto>>> Handle(GetCommemtByPostIdQuery request, CancellationToken cancellationToken)
        {

            var comments = await _unitOfWork.Repository<Comment>().Entities.Where(a => a.PostId.Equals(request.id))
                .ProjectTo<GetCommemtByPostIdDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);


            return await Result<List<GetCommemtByPostIdDto>>.SuccessAsync(comments);
        }
    }
}

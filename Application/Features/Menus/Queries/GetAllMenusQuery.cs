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

namespace Application.Features.Menus.Queries
{
  
    public record GetAllMenusQuery : IRequest<Result<List<GetAllMenusDto>>>;

    internal class GetAllMenuQueryHandler : IRequestHandler<GetAllMenusQuery, Result<List<GetAllMenusDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllMenuQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllMenusDto>>> Handle(GetAllMenusQuery request, CancellationToken cancellationToken)
        {

            var menu = await _unitOfWork.Repository<Menu>().Entities
                .ProjectTo<GetAllMenusDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllMenusDto>>.SuccessAsync(menu);
        }
    }
}

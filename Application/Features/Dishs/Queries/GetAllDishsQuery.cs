using Application.Features.DishCategorys.Queries;
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

namespace Application.Features.Dishs.Queries
{

    public record GetAllDishsQuery : IRequest<Result<List<GetAllDishsDto>>>;

    internal class GetAllDishsQueryHandler : IRequestHandler<GetAllDishsQuery, Result<List<GetAllDishsDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDishsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDishsDto>>> Handle(GetAllDishsQuery request, CancellationToken cancellationToken)
        {

            var dish = await _unitOfWork.Repository<Dish>().Entities
                .ProjectTo<GetAllDishsDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllDishsDto>>.SuccessAsync(dish);
        }
    }
}

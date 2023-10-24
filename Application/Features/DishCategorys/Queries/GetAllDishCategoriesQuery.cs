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

namespace Application.Features.DishCategorys.Queries
{
    
    public record GetAllDishCategoriesQuery : IRequest<Result<List<GetAllDishCategoriesDto>>>;

    internal class GetAllDishCategoryQueryHandler : IRequestHandler<GetAllDishCategoriesQuery, Result<List<GetAllDishCategoriesDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetAllDishCategoryQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<GetAllDishCategoriesDto>>> Handle(GetAllDishCategoriesQuery request, CancellationToken cancellationToken)
        {

            var dishCategory = await _unitOfWork.Repository<DishCategory>().Entities
                .ProjectTo<GetAllDishCategoriesDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return await Result<List<GetAllDishCategoriesDto>>.SuccessAsync(dishCategory);
        }
    }
}

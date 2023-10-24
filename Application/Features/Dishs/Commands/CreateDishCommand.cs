using Application.Common.Mappings;
using Application.Features.DishCategorys.Commands;
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

namespace Application.Features.Dishs.Commands
{
    public record CreateDishCommand : IRequest<Result<Guid>>, IMapFrom<Dish>
    {
        public string DishName { get; set; }
        public Guid MenuId { get; set; }
        public Guid DishCategoryId { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public byte IsDeleted { get; set; }
        public string? DishImage { get; set; }
        public string? DishIngredients { get; set; }

    }


    public class CreateDishCommandHandler : IRequestHandler<CreateDishCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDishCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateDishCommand command, CancellationToken cancellationToken)
        {
            var dish = new Dish()
            {
                DishName= command.DishName,
                MenuId= command.MenuId,
                Price= command.Price,
                IsDeleted= command.IsDeleted,
                Description= command.Description,
                DishCategoryId = command.DishCategoryId,
                DishImage = command.DishImage,
                DishIngredients = command.DishIngredients,

            };

            await _unitOfWork.Repository<Dish>().AddAsync(dish);
            dish.AddDomainEvent(new DishCreateEvent(dish));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(dish.Id, $"Dish: {dish.Id} Created.");
        }


    }
}

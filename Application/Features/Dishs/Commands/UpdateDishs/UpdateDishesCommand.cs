using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.Dishes.Commands.UpdateDishes
{
    public class UpdateDishesCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string DishName { get; set; }
        public Guid MenuId { get; set; }
        public Guid DishCategoryId { get; set; }
        public string? Description { get; set; }
        public float Price { get; set; }
        public byte IsDeleted { get; set; }
        public string? DishImage { get; set; }
        public string? DishIngredients { get; set; }


    }

    internal class UpdateDishesCommandHandler : IRequestHandler<UpdateDishesCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDishesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateDishesCommand command, CancellationToken cancellationToken)
        {
            var dish = await _unitOfWork.Repository<Dish>().GetByIdAsync(command.Id);
            if (dish != null)
            {
                dish.DishName = command.DishName;
                dish.Description = command.Description;
                dish.MenuId = command.MenuId;
                dish.DishCategoryId = command.DishCategoryId;
                dish.Price = command.Price;
                dish.IsDeleted = command.IsDeleted;
                dish.DishImage = command.DishImage;
                dish.LastModifiedDate = DateTime.Now;
                dish.DishIngredients = command.DishIngredients;
                await _unitOfWork.Repository<Dish>().UpdateAsync(dish);
                dish.AddDomainEvent(new DishesUpdatedEvent(dish));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(dish.Id, "Dish Updated.");
            }
            else
            {
                await Result<Guid>.FailureAsync("Dish Not Found.");
                throw new NotFoundException();
            }
        }
    }
}

using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.Dishes.Commands.DeleteDishes
{
    public class DeleteDishesCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        //public int Roles { get; set; }


    }

    internal class DeleteDishesCommandHandler : IRequestHandler<DeleteDishesCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDishesCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteDishesCommand command, CancellationToken cancellationToken)
        {
            var dish = await _unitOfWork.Repository<Dish>().GetByIdAsync(command.Id);
            if (dish != null)
            {
                dish.IsDeleted = 1;
                dish.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Dish>().UpdateAsync(dish);
                dish.AddDomainEvent(new DishesDeletedEvent(dish));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(dish.Id, "Dish Deleted.");
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}

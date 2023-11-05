using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.DishCategorys.Commands.DeleteDishCategorys
{
    public class DeleteDishCategoryCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        //public int Roles { get; set; }


    }

    internal class DeleteDishCategoryCommandHandler : IRequestHandler<DeleteDishCategoryCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteDishCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteDishCategoryCommand command, CancellationToken cancellationToken)
        {
            var dishCategory = await _unitOfWork.Repository<DishCategory>().GetByIdAsync(command.Id);
            if (dishCategory != null)
            {
                dishCategory.isActived = 0;
                dishCategory.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<DishCategory>().UpdateAsync(dishCategory);
                dishCategory.AddDomainEvent(new DishCategoryDeletedEvent(dishCategory));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(dishCategory.Id, "DishCategory Deleted.");
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}

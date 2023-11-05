using Application.Features.DishCategorys.Commands.UpdateDishCategorys;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.DishCategorys.Commands.UpdateDishCategorys
{
    public class UpdateDishCategoryCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public byte isActived { get; set; }


    }

    internal class UpdateDishCategoryCommandHandler : IRequestHandler<UpdateDishCategoryCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateDishCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateDishCategoryCommand command, CancellationToken cancellationToken)
        {
            var dishCategory = await _unitOfWork.Repository<DishCategory>().GetByIdAsync(command.Id);
            if (dishCategory != null)
            {
                dishCategory.Name = command.Name;
                dishCategory.Description = command.Description;
                dishCategory.Image = command.Image;
                dishCategory.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<DishCategory>().UpdateAsync(dishCategory);
                dishCategory.AddDomainEvent(new DishCategoryUpdatedEvent(dishCategory));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(dishCategory.Id, "DishCategory Updated.");
            }
            else
            {
                await Result<Guid>.FailureAsync("DishCategory Not Found.");
                throw new NotFoundException();
            }
        }
    }
}

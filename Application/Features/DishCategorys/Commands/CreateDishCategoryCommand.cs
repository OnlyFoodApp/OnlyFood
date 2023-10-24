using Application.Common.Mappings;
using Application.Features.Comments.Commands;
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

namespace Application.Features.DishCategorys.Commands
{

    public record CreateDishCategoryCommand : IRequest<Result<Guid>>, IMapFrom<DishCategory>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? Image { get; set; }
        public byte isActived { get; set; }

    }


    internal class CreateDishCategoryCommandHandler : IRequestHandler<CreateDishCategoryCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateDishCategoryCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateDishCategoryCommand command, CancellationToken cancellationToken)
        {
            var dishCategory = new DishCategory()
            {
                Name = command.Name,
                Description = command.Description,
                Image = command.Image,
                isActived = command.isActived,


            };

            await _unitOfWork.Repository<DishCategory>().AddAsync(dishCategory);
            dishCategory.AddDomainEvent(new DishCategoryCreateEvent(dishCategory));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(dishCategory.Id, $"DishCategory: {dishCategory.Id} Created.");
        }


    }
}

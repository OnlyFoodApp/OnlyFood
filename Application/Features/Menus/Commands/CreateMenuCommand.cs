using Application.Common.Mappings;
using Application.Features.Dishs.Commands;
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

namespace Application.Features.Menus.Commands
{
    public record CreateMenuCommand : IRequest<Result<Guid>>, IMapFrom<Dish>
    {
        public byte IsDeleted { get; set; }
        public byte IsEdited { get; set; }
        public Guid CampaignId { get; set; }

    }


    public class CreateMenuCommandHandler : IRequestHandler<CreateMenuCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateMenuCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateMenuCommand command, CancellationToken cancellationToken)
        {
            var menu = new Menu()
            {
                IsDeleted = command.IsDeleted,
                IsEdited = command.IsEdited,
                CampaignId = command.CampaignId,

            };

            await _unitOfWork.Repository<Menu>().AddAsync(menu);
            menu.AddDomainEvent(new MenuCreateEvent(menu));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(menu.Id, $"Menu: {menu.Id} Created.");
        }


    }
}

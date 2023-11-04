using Application.Features.Menus.Commands.DeleteMenu;
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

namespace Application.Features.Menus.Commands.UpdateMenu
{
   
    public class UpdateMenuCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        
        public Guid CampaignId { get; set; }


    }

    internal class DeleteAccountCommandHandler : IRequestHandler<UpdateMenuCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteAccountCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateMenuCommand command, CancellationToken cancellationToken)
        {
            var menu = await _unitOfWork.Repository<Menu>().GetByIdAsync(command.Id);
            if (menu != null)
            {
                menu.IsEdited = 1;
                menu.CampaignId = command.CampaignId;
                menu.ModifiedBy = command.Id;
                menu.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Menu>().UpdateAsync(menu);
                menu.AddDomainEvent(new MenuDeletedEvent(menu));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(menu.Id, "Menu Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Menu Not Found.");
            }
        }
    }
}

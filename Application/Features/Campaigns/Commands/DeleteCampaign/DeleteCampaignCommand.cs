using Application.Features.Campaigns.Commands.UpdateCampaign;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.DeleteCampaign
{
    public class DeleteCampaignCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        //public int Roles { get; set; }


    }

    internal class DeleteCampaignCommandHandler : IRequestHandler<DeleteCampaignCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCampaignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteCampaignCommand command, CancellationToken cancellationToken)
        {
            var campaign = await _unitOfWork.Repository<Campaign>().GetByIdAsync(command.Id);
            if (campaign != null)
            {
                campaign.Status = 0;
                campaign.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Campaign>().UpdateAsync(campaign);
                campaign.AddDomainEvent(new CampaignDeletedEvent(campaign));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(campaign.Id, "Campaign Deleted.");
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}

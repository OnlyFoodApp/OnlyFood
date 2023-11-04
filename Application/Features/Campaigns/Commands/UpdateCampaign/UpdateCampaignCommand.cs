using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;


namespace Application.Features.Campaigns.Commands.UpdateCampaign
{
    public class UpdateCampaignCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string CampaignName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public byte Status { get; set; }
        //public int Roles { get; set; }


    }

    internal class UpdateCampaignCommandHandler : IRequestHandler<UpdateCampaignCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCampaignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateCampaignCommand command, CancellationToken cancellationToken)
        {
            var campaign = await _unitOfWork.Repository<Campaign>().GetByIdAsync(command.Id);
            if (campaign != null)
            {
                campaign.CampaignName = command.CampaignName;
                campaign.Description = command.Description;
                campaign.StartDate = command.StartDate;
                campaign.EndDate = command.EndDate;
                campaign.Status = command.Status;
                await _unitOfWork.Repository<Campaign>().UpdateAsync(campaign);
                campaign.AddDomainEvent(new CampaignUpdatedEvent(campaign));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(campaign.Id, "Campaign Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Campaign Not Found.");
            }
        }
    }
}

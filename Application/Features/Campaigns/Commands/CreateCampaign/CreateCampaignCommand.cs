using Application.Common.Mappings;
using Application.Features.Accounts.Commands.CreateAccount;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Campaigns.Commands.CreateCampaign
{
    public record CreateCampaignCommand : IRequest<Result<Guid>>, IMapFrom<Campaign>
    {
        public string CampaignName { get; set; }
        public string? Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Guid ChefID { get; set; }
        public byte Status { get; set; }

    }

    internal class CreateCampaignCommandHandler : IRequestHandler<CreateCampaignCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCampaignCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateCampaignCommand command, CancellationToken cancellationToken)
        {
            var campaign = new Campaign()
            {
                CampaignName = command.CampaignName,
                Description = command.Description,
                EndDate = command.EndDate,
                StartDate = command.StartDate,
                Status = command.Status,
                ChefID = command.ChefID,
                CreatedBy = command.ChefID,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
                ModifiedBy = command.ChefID
            };

            await _unitOfWork.Repository<Campaign>().AddAsync(campaign);
            campaign.AddDomainEvent(new CampaignCreatedEvent(campaign));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(campaign.Id, $"Campaign: {campaign.Id} Created.");
        }
    }
}

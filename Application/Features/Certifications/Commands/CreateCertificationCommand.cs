using Application.Common.Mappings;
using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Certifications.Commands
{
    public record CreateCertificationCommand : IRequest<Result<Guid>>, IMapFrom<Certification>
    {
        public string Name { get; set; }
        public Guid ChefID { get; set; }
        public string IssuingAuthority { get; set; }
        public string CertificationDescription { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string CertificationURL { get; set; }
        public byte IsValid { get; set; }
        
    }


    internal class CreateCertificationCommandHandler : IRequestHandler<CreateCertificationCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCertificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateCertificationCommand command, CancellationToken cancellationToken)
        {
            var certification = new Certification()
            {
                Name = command.Name,
                ChefID = command.ChefID,
                IssuingAuthority = command.IssuingAuthority,
                CertificationDescription = command.CertificationDescription,
                EffectiveDate = command.EffectiveDate,
                ExpirationDate = command.ExpirationDate,
                CertificationURL = command.CertificationURL,
                IsValid = command.IsValid,
            };

            await _unitOfWork.Repository<Certification>().AddAsync(certification);
            certification.AddDomainEvent(new CertificationCreateEvent(certification));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(certification.Id, $"Certification: {certification.Id} Created.");
        }

        
    }
}

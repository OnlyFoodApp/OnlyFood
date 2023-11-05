using Application.Features.Certifications.Commands.UpdateCertifications;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Enums;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.Certifications.Commands.UpdateCertification
{
    public class UpdateCertificationCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid ChefID { get; set; }
        public string IssuingAuthority { get; set; }
        public string CertificationDescription { get; set; }
        public string EffectiveDate { get; set; }
        public string ExpirationDate { get; set; }
        public string CertificationURL { get; set; }
        public byte IsValid { get; set; }
        //public int Roles { get; set; }


    }

    internal class UpdateCertificationCommandHandler : IRequestHandler<UpdateCertificationCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateCertificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateCertificationCommand command, CancellationToken cancellationToken)
        {
            var certification = await _unitOfWork.Repository<Certification>().GetByIdAsync(command.Id);
            if (certification != null)
            {
                certification.Name = command.Name;
                certification.IssuingAuthority = command.IssuingAuthority;
                certification.CertificationDescription = command.CertificationDescription;
                certification.EffectiveDate = command.EffectiveDate;
                certification.ExpirationDate = command.ExpirationDate;
                certification.CertificationURL = command.CertificationURL;
                certification.IsValid = command.IsValid;
                certification.ModifiedBy = command.ChefID;
                await _unitOfWork.Repository<Certification>().UpdateAsync(certification);
                certification.AddDomainEvent(new CertificationUpdatedEvent(certification));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(certification.Id, "Certification Updated.");
            }
            else
            {
                await Result<Guid>.FailureAsync("Certification Not Found.");
                throw new NotFoundException();
            }
        }
    }
}

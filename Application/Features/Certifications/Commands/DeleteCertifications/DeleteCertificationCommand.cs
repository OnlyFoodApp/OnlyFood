using Application.Features.Certifications.Commands.DeleteCertification;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using Domain.Exceptions;
using MediatR;
using Shared;


namespace Application.Features.Certifications.Commands.DeleteCertification
{
    public class DeleteCertificationCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        //public int Roles { get; set; }


    }

    internal class DeleteCertificationCommandHandler : IRequestHandler<DeleteCertificationCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCertificationCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteCertificationCommand command, CancellationToken cancellationToken)
        {
            var certification = await _unitOfWork.Repository<Certification>().GetByIdAsync(command.Id);
            if (certification != null)
            {
                certification.IsValid = 0;
                certification.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Certification>().UpdateAsync(certification);
                certification.AddDomainEvent(new CertificationDeletedEvent(certification));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(certification.Id, "Certification Deleted.");
            }
            else
            {
                throw new NotFoundException();
            }
        }
    }
}

using Application.Interfaces.Repositories;
using AutoMapper;
using MediatR;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Application.Features.Payments.Commands.UpdatePayment
{
    public class UpdatePaymentCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public byte IsActived { get; set; }
        public Guid CreateBy { get; set; }
        public Guid ModifiedBy { get; set; }
        public DateTime LastModifiedDate { get; set; } = DateTime.Now;


    }

    internal class UpdatePaymentCommandHandler : IRequestHandler<UpdatePaymentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdatePaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdatePaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.Repository<Payment>().GetByIdAsync(command.Id);
            if (payment != null)
            {
                payment.Name = command.Name;
                payment.Description = command.Description;
                payment.IsActived = command.IsActived;
                payment.CreatedBy = command.CreateBy;
                payment.ModifiedBy = command.ModifiedBy;
                payment.LastModifiedDate = command.LastModifiedDate;
                await _unitOfWork.Repository<Payment>().UpdateAsync(payment);
                payment.AddDomainEvent(new PaymentUpdatedEvent(payment));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(payment.Id, "Payment Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Payment Not Found.");
            }
        }
    }
}

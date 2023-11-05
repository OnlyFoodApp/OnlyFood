using Application.Features.Payments.Commands.UpdatePayment;
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

namespace Application.Features.Payments.Commands.DeletePayment
{
    
    public class DeletePaymentCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        


    }

    internal class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeletePaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeletePaymentCommand command, CancellationToken cancellationToken)
        {
            var payment = await _unitOfWork.Repository<Payment>().GetByIdAsync(command.Id);
            if (payment != null)
            {
                payment.IsActived = 0;
                payment.ModifiedBy = command.Id;
                payment.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Payment>().UpdateAsync(payment);
                payment.AddDomainEvent(new PaymentDeletedEvent(payment));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(payment.Id, "Payment Deleted.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Payment Not Found.");
            }
        }
    }
}

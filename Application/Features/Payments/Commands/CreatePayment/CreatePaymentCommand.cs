using Application.Common.Mappings;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;


namespace Application.Features.Payments.Commands.CreatePayment
{
    public class CreatePaymentCommand : IRequest<Result<Guid>>, IMapFrom<Payment>
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public byte IsActived { get; set; }

    }

    internal class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreatePaymentCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreatePaymentCommand command, CancellationToken cancellationToken)
        {


            var payment = new Payment()
            {
                Name = command.Name,
                Description = command.Description,
                IsActived = command.IsActived,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };



            await _unitOfWork.Repository<Payment>().AddAsync(payment);
            payment.AddDomainEvent(new PaymentCreateEvent(payment));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(payment.Id, "Payment Created.");
        }
    }
}

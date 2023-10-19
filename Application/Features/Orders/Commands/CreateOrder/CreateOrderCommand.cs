using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Common.Mappings;
using Application.Features.Accounts.Commands.CreateAccount;
using Application.Features.Chef.Commands.CreateChef;
using Application.Interfaces.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using Shared;

namespace Application.Features.Orders.Commands.CreateOrder
{
    public class CreateOrderCommand : IRequest<Result<Guid>>, IMapFrom<Order>
    {
        public DateTime OrderDate { get; set; }
        public Guid CustomerId { get; set; }
        public Guid PaymentId { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
        public float TotalAmount { get; set; }
        public int NumberOfItems { get; set; }
        public float Discount { get; set; }
        public int Status { get; set; }

    }

    internal class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateOrderCommand command, CancellationToken cancellationToken)
        {


            var order = new Order()
            {
                OrderDate = command.OrderDate,
                CustomerId = command.CustomerId,
                PaymentId = command.PaymentId,
                ExpectedDeliveryTime = command.ExpectedDeliveryTime,
                TotalAmount = command.TotalAmount,
                NumberOfItems = command.NumberOfItems,
                Discount = command.Discount,
                Status = command.Status,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };



            await _unitOfWork.Repository<Order>().AddAsync(order);
            order.AddDomainEvent(new OrderCreateEvent(order));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(order.Id, "Order Created.");
        }
    }
}

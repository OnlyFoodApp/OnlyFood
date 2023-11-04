using Application.Features.Orders.Commands.DeleteOrder;
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

namespace Application.Features.Orders.Commands.UpdateOrder
{

    public class UpdateOrderCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }
        public DateTime OrderDate { get; set; }
        
        public Guid PaymentId { get; set; }
        public DateTime ExpectedDeliveryTime { get; set; }
        public float TotalAmount { get; set; }
        public int NumberOfItems { get; set; }
        public float Discount { get; set; }
        public int Status { get; set; }
    }

    internal class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(UpdateOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.Id);
            if (order != null)
            {
                order.OrderDate = command.OrderDate;
                order.PaymentId = command.PaymentId;
                order.ExpectedDeliveryTime = command.ExpectedDeliveryTime;
                order.TotalAmount = command.TotalAmount;    
                order.NumberOfItems = command.NumberOfItems;
                order.Discount = command.Discount;  
                order.Status = command.Status;
                order.ModifiedBy = command.Id;
                order.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Order>().UpdateAsync(order);
                order.AddDomainEvent(new OrderUpdatedEvent(order));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(order.Id, "Order Updated.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Order Not Found.");
            }
        }
    }
}

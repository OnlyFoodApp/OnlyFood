using Application.Common.Mappings;
using Application.Features.Orders.Commands.CreateOrder;
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

namespace Application.Features.OrderDetails.Commands.CreateOrderDetail
{
    
    public class CreateOrderDetailCommand : IRequest<Result<Guid>>, IMapFrom<Order>
    {
        
        public Guid OrderId { get; set; }
        public Guid DishId { get; set; }
        public int Quantity { get; set; }
        public float UnitPrice { get; set; }
        public byte IsCancelled { get; set; }

    }

    internal class CreateOrderDetailCommandHandler : IRequestHandler<CreateOrderDetailCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateOrderDetailCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(CreateOrderDetailCommand command, CancellationToken cancellationToken)
        {


            var orderDetail = new OrderDetail()
            {
                OrderId = command.OrderId,
                DishId = command.DishId,
                Quantity = command.Quantity,
                UnitPrice = command.UnitPrice,
                IsCancelled = command.IsCancelled,
                CreatedDate = DateTime.Now,
                LastModifiedDate = DateTime.Now,
            };



            await _unitOfWork.Repository<OrderDetail>().AddAsync(orderDetail);
            orderDetail.AddDomainEvent(new OrderDetailCreatedEvent(orderDetail));
            await _unitOfWork.Save(cancellationToken);
            return await Result<Guid>.SuccessAsync(orderDetail.Id, "OrderDetail Created.");
        }
    }
}

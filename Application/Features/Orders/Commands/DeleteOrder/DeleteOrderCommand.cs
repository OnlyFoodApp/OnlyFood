using Application.Features.Likes.Commands.DeleteLike;
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

namespace Application.Features.Orders.Commands.DeleteOrder
{
    
    public class DeleteOrderCommand : IRequest<Result<Guid>>
    {
        public Guid Id { get; set; }

        public DeleteOrderCommand()
        {

        }

        public DeleteOrderCommand(Guid id)
        {
            Id = id;
        }
    }

    internal class UpdateOrderCommandHandler : IRequestHandler<DeleteOrderCommand, Result<Guid>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateOrderCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Guid>> Handle(DeleteOrderCommand command, CancellationToken cancellationToken)
        {
            var order = await _unitOfWork.Repository<Order>().GetByIdAsync(command.Id);
            if (order != null)
            {
                order.Status = 0;
                order.ModifiedBy = command.Id;
                order.LastModifiedDate = DateTime.Now;
                await _unitOfWork.Repository<Order>().UpdateAsync(order);
                order.AddDomainEvent(new OrderDeletedEvent(order));

                await _unitOfWork.Save(cancellationToken);

                return await Result<Guid>.SuccessAsync(order.Id, "Order Deleted.");
            }
            else
            {
                return await Result<Guid>.FailureAsync("Order Not Found.");
            }
        }
    }
}

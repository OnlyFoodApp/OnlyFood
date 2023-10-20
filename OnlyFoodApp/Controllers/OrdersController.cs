
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetEarningDataOfCustomerBaseOnOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class OrdersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllOrdersDto>>>> GetAllOrderAsync()
        {
            return await _mediator.Send(new GetAllOrdersQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateOrders(CreateOrderCommand order)
        {
            var a = order;
            return await _mediator.Send(order);
        }
        [HttpGet]
        [Route("getEarningDataOfCustomerBaseOnOrder")]
        public async Task<Result<GetEarningDataOfCustomerBaseOnOrderDto>> GetEarningDataOfCustomerBaseOnOrderAsync()
        {
            return await _mediator.Send(new GetEarningDataOfCustomerBaseOnOrderQuery());
        }
    }
}

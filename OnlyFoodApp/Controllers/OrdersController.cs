
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetEarningDataBaseOnOrder;
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
        [Route("dataBaseOnOrder")]
        public async Task<Result<GetEarningDataBaseOnOrderDto>> GetEarningDataBaseOnOrderAsync()
        {
            return await _mediator.Send(new GetEarningDataBaseOnOrderQuery());
        }
    }
}

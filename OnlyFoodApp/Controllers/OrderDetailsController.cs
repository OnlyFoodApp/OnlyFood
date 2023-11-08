using Application.Features.Menus.Commands.DeleteMenu;
using Application.Features.OrderDetails.Commands.CreateOrderDetail;
using Application.Features.OrderDetails.Queries.GetAllOrderDetail;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetEarningDataBaseOnOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    
    public class OrderDetailsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public OrderDetailsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]

        public async Task<ActionResult<Result<List<GetAllOrderDetailsDto>>>> GetAllOrderAsync()
        {
            return await _mediator.Send(new GetAllOrderDetailsQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateOrders(CreateOrderDetailCommand order)
        {
            var a = order;
            return await _mediator.Send(order);
        }
       

    }
}

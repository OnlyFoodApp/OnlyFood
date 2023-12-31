﻿
using Application.Features.Menus.Commands.DeleteMenu;
using Application.Features.Menus.Commands.UpdateMenu;
using Application.Features.Orders.Commands.CreateOrder;
using Application.Features.Orders.Commands.DeleteOrder;
using Application.Features.Orders.Commands.UpdateOrder;
using Application.Features.Orders.Queries.GetAllOrders;
using Application.Features.Orders.Queries.GetEarningDataBaseOnOrder;
using Application.Features.Orders.Queries.GetEarningDataOfCustomerBaseOnOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

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
        [Route("all")]

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
        [Route("revenue/dataBaseOnOrder")]
        public async Task<Result<GetEarningDataBaseOnOrderDto>> GetEarningDataBaseOnOrderAsync()
        {
            return await _mediator.Send(new GetEarningDataBaseOnOrderQuery());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id)
        {

            return await _mediator.Send(new DeleteOrderCommand(id));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdateOrderCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }
    }
}

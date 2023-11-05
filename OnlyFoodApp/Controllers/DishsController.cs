using Application.Common.Response;
using Application.Features.Dishes.Commands.DeleteDishes;
using Application.Features.Dishes.Commands.UpdateDishes;
using Application.Features.Dishs.Commands;
using Application.Features.Dishs.Queries;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Net;

namespace OnlyFoodApp.Controllers
{
    public class DishsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public DishsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllDishsDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllDishsQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateDish(CreateDishCommand dish)
        {
            var a = dish;
            return await _mediator.Send(dish);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateDishesCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Dishes Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Dishes updated successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Dishes not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this Dishes. Because: {ex.Message}!.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteDishesCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Dishes Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Dishes deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Dishes not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this Dishes. Because: {ex.Message}!.");
            }
        }
    }
}

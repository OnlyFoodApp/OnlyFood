using Application.Common.Response;
using Application.Features.DishCategorys.Commands;
using Application.Features.DishCategorys.Commands.DeleteDishCategorys;
using Application.Features.DishCategorys.Commands.UpdateDishCategorys;
using Application.Features.DishCategorys.Queries;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Net;

namespace OnlyFoodApp.Controllers
{

    public class DishCategoriesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public DishCategoriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllDishCategoriesDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllDishCategoriesQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateDishCategory(CreateDishCategoryCommand dishCategory)
        {
            var a = dishCategory;
            return await _mediator.Send(dishCategory);
        }


        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateDishCategoryCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "DishCategory Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "DishCategory updated successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "DishCategory not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this DishCategory. Because: {ex.Message}!.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteDishCategoryCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "DishCategory Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "DishCategory deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "DishCategory not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this DishCategory. Because: {ex.Message}!.");
            }
        }
    }
}

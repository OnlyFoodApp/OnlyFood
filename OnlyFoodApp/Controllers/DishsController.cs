using Application.Features.Comments.Commands;
using Application.Features.Comments.Queries;
using Application.Features.Dishs.Commands;
using Application.Features.Dishs.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

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
    }
}

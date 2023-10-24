using Application.Features.Comments.Commands;
using Application.Features.Comments.Queries;
using Application.Features.DishCategorys.Commands;
using Application.Features.DishCategorys.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

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
    }
}

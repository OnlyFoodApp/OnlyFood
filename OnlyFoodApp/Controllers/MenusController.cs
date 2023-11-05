using Application.Features.Accounts.Commands.DeleteAccount;
using Application.Features.Dishs.Commands;
using Application.Features.Dishs.Queries;
using Application.Features.Likes.Commands.UpdateLike;
using Application.Features.Menus.Commands;
using Application.Features.Menus.Commands.DeleteMenu;
using Application.Features.Menus.Commands.UpdateMenu;
using Application.Features.Menus.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class MenusController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public MenusController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllMenusDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllMenusQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateDish(CreateMenuCommand menu)
        {
            var a = menu;
            return await _mediator.Send(menu);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id, DeleteMenuCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdateMenuCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }
    }
}

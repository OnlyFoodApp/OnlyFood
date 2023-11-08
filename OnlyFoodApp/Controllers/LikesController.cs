using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Features.Certifications.Commands;
using Application.Features.Certifications.Queries;
using Application.Features.Likes.Commands;
using Application.Features.Likes.Commands.UpdateLike;
using Application.Features.Likes.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class LikesController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public LikesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]

        public async Task<ActionResult<Result<List<GetAllLikesDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllLikesQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateLikes(CreateLikeCommand like)
        {
            var a = like;
            return await _mediator.Send(like);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdateLikeCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }
    }
}

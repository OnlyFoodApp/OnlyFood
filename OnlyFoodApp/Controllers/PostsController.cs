using Application.Features.Certifications.Commands;
using Application.Features.Certifications.Queries;
using Application.Features.Payments.Commands.DeletePayment;
using Application.Features.Payments.Commands.UpdatePayment;
using Application.Features.Posts.Commands;
using Application.Features.Posts.Commands.DeletePost;
using Application.Features.Posts.Commands.UpdatePost;
using Application.Features.Posts.Queries;
using Application.Features.Posts.Queries.GetCommemtByPostId;
using Application.Features.Posts.Queries.GetPostById;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class PostsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PostsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllPostsDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllPostsQuery ());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreatePost([FromForm]CreatePostCommand post)
        {
            var a = post;
            return await _mediator.Send(post);
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetPostByIdDto>>> GetPostByPostIdAsync(String id)
        {
            return await _mediator.Send(new GetPostByPostIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdatePostCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id, DeletePostCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }
    }
}

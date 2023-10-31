using Application.Features.Certifications.Commands;
using Application.Features.Certifications.Queries;
using Application.Features.Posts.Commands;
using Application.Features.Posts.Queries;
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
    }
}

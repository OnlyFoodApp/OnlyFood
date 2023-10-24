using Application.Features.Certifications.Commands;
using Application.Features.Certifications.Queries;
using Application.Features.Comments.Commands;
using Application.Features.Comments.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class CommentsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CommentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCommentsDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllCommentsQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateComment(CreateCommentCommand comment)
        {
            var a = comment;
            return await _mediator.Send(comment);
        }
    }
}

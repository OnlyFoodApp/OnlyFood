using Application.Common.Response;
using Application.Features.Comments.Commands;
using Application.Features.Comments.Queries;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Net;
using Application.Features.Comments.Commands.UpdateComments;
using Application.Features.Comments.Commands.DeleteComments;
using Application.Features.Posts.Queries.GetCommemtByPostId;

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
        [HttpGet("{id}")]
        public async Task<ActionResult<Result<List<GetCommemtByPostIdDto>>>> GetCommemtByPostIdAsync(String id)
        {
            return await _mediator.Send(new GetCommemtByPostIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }



        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateCommentCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Comment Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Comment updated successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Comment not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this Comment. Because: {ex.Message}!.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteCommentCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Comment Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Comment deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Comment not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this Comment. Because: {ex.Message}!.");
            }
        }
    }
}

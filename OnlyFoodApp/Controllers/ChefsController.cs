
using Application.Common.Response;
using Application.Features.Chefs.Commands.DeleteChef;
using Application.Features.Chefs.Commands.UpdateChef;
using Application.Features.Chefs.Commands.CreateChef;
using Application.Features.Chefs.Queries.GetAllChefs;
using Application.Features.Chefs.Queries.GetChefsWithPagination;
using Application.Features.Chefs.Queries.GetChefWithId;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Net;

namespace OnlyFoodApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class ChefsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ChefsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]
        public async Task<ActionResult<Result<List<GetAllChefsDto>>>> GetAllAccountAsync()
        {
            return await _mediator.Send(new GetAllChefsQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetChefsWithPaginationDto>>> GetChefsWithPagination([FromQuery] GetChefsWithPaginationQuery query)
        {
            var validator = new GetChefsWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }


        [HttpPost]
        public async Task<Result<Guid>> CreateAccount(CreateChefCommand account)
        {
            var a = account;
            return await _mediator.Send(account);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetChefWithIdDto>>> GetChefByIdAsync(String id)
        {
            return await _mediator.Send(new GetChefWithIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateChefCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Chef Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Chef updated successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Chef not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this Chef. Because: {ex.Message}!.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteChefCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Chef Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Chef deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Chef not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this Chef. Because: {ex.Message}!.");
            }
        }
    }
}

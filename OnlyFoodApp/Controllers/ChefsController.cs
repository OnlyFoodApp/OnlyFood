
using Application.Features.Chefs.Commands.CreateChef;
using Application.Features.Chefs.Queries.GetAllChefs;
using Application.Features.Chefs.Queries.GetChefsWithPagination;
using Application.Features.Chefs.Queries.GetChefWithId;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    [Authorize(Roles = "Chef")]
    public class ChefsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public ChefsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
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

        [HttpGet]
        [Route("id")]
        public async Task<ActionResult<Result<GetChefWithIdDto>>> GetChefByIdAsync([FromQuery] String id)
        {
            return await _mediator.Send(new GetChefWithIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }
    }
}

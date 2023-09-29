using Application.Features.Accounts.Commands.CreateAccount;
using Application.Features.Accounts.Queries.GetAccountsWithPagination;
using Application.Features.Accounts.Queries.GetAllAccounts;
using Application.Features.Chef.Querries.GetAllChefs;
using Application.Features.Chef.Querries.GetChefsWithPagination;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyFoodApp.Enums;
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
        public async Task<Result<Guid>> CreateAccount(CreateAccountCommand account)
        {
            var a = account;
            return await _mediator.Send(account);
        }
    }
}

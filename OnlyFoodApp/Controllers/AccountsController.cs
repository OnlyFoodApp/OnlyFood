using Application.Features.Accounts.Queries.GetAccountsWithPagination;
using Application.Features.Accounts.Queries.GetAllAccounts;
using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    //[Route("api/v1/[controller]")]
    //[ApiController]
    public class AccountsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllAccountsDto>>>> GetAllAccountAsync()
        {
            return await _mediator.Send(new GetAllAccountsQuery());
        }

        [HttpGet]
        [Route("paged")]
        public async Task<ActionResult<PaginatedResult<GetAccountsWithPaginationDto>>> GetAccountsWithPagination([FromQuery] GetAccountsWithPaginationQuery query)
        {
            var validator = new GetAccountsWithPaginationValidator();

            // Call Validate or ValidateAsync and pass the object which needs to be validated
            var result = validator.Validate(query);

            if (result.IsValid)
            {
                return await _mediator.Send(query);
            }

            var errorMessages = result.Errors.Select(x => x.ErrorMessage).ToList();
            return BadRequest(errorMessages);
        }
    }
}

using Application.Features.Accounts.Commands.CreateAccount;
using Application.Features.Accounts.Queries.GetAccountsWithPagination;
using Application.Features.Accounts.Queries.GetAllAccounts;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Shared;
using Application.Features.Accounts.Commands.DeleteAccount;
using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Features.Accounts.Queries.GetAccountById;


namespace OnlyFoodApp.Controllers
{
    //[Route("api/v1/[controller]")]
    //[ApiController]
    [Authorize(Roles = "Admin")]
    public class AccountsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public AccountsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        //[Route("getAllAccount")]
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


        [HttpPost]
        public async Task<Result<Guid>> CreateAccount(CreateAccountCommand account)
        {
            var a = account;
            return await _mediator.Send(account);
        }

        [HttpGet("{id}")]
        //[Route("id")]
        public async Task<ActionResult<Result<GetAccountWithIdDto>>> GetAccountByIdAsync(String id)
        {
            return await _mediator.Send(new GetAccountWithIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdateAccountCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpPut("delete/{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id, DeleteAccountCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }
    }
}

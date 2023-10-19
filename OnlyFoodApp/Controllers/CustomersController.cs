
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Queries.GetAllCustomers;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class CustomersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCustomersDto>>>> GetAllAccountAsync()
        {
            return await _mediator.Send(new GetAllCustomersQuery());
        }


        [HttpPost]
        public async Task<Result<Guid>> CreateAccount(CreateCustomerCommand account)
        {
            var a = account;
            return await _mediator.Send(account);
        }

        
    }
}

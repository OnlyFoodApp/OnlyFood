
using Application.Common.Response;
using Application.Features.Customers.Commands.DeleteCustomer;
using Application.Features.Customers.Commands.UpdateCustomer;
using Application.Features.Customers.Commands.CreateCustomer;
using Application.Features.Customers.Queries.GetAllCustomers;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OnlyFoodApp.Enums;
using Shared;
using System.Net;
using Application.Features.Posts.Queries.GetCommemtByPostId;
using Application.Features.Customers.Queries.GetCustomerById;

namespace OnlyFoodApp.Controllers
{
    [Authorize(Roles = "Admin")]
    public class CustomersController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CustomersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]

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

        [HttpGet("{id}")]
        public async Task<ActionResult<Result<GetCustomerByIdDto>>> GetCustomerByIdAsync(String id)
        {
            return await _mediator.Send(new GetCustomerByIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateCustomerCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Customer Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Customer updated successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Customer not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this Customer. Because: {ex.Message}!.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteCustomerCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Customer Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Customer deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Customer not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this Customer. Because: {ex.Message}!.");
            }
        }
    }
}

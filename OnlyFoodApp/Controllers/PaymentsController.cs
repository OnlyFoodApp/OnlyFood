
using Application.Features.Menus.Commands.DeleteMenu;
using Application.Features.Payments.Commands.CreatePayment;
using Application.Features.Payments.Commands.DeletePayment;
using Application.Features.Payments.Commands.UpdatePayment;
using Application.Features.Payments.Queries.GetAllPayments;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

namespace OnlyFoodApp.Controllers
{
    public class PaymentsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public PaymentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("all")]

        public async Task<ActionResult<Result<List<GetAllPaymentsDto>>>> GetAllPaymentAsync()
        {
            return await _mediator.Send(new GetAllPaymentsQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreatePayments(CreatePaymentCommand payment)
        {
            var a = payment;
            return await _mediator.Send(payment);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<Result<Guid>>> Update(Guid id, UpdatePaymentCommand command)
        {
            if (!id.Equals(command.Id) )
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<ActionResult<Result<Guid>>> Delete(Guid id, DeletePaymentCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return BadRequest();
            }

            return await _mediator.Send(command);
        }
    }
}

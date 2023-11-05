using Application.Common.Response;
using Application.Features.Certifications.Commands.UpdateCertification;
using Application.Features.Certifications.Commands.DeleteCertification;
using Application.Features.Certifications.Commands;
using Application.Features.Certifications.Queries;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Net;


namespace OnlyFoodApp.Controllers
{
    public class CertificationsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CertificationsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCertificationsDto>>>> GetAll()
        {
            return await _mediator.Send(new GetAllCertificationsQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateCertification(CreateCertificationCommand certification)
        {
            var a = certification;
            return await _mediator.Send(certification);
        }
        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateCertificationCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Certification Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Certification updated successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Certification not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this Certification. Because: {ex.Message}!.");
            }
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteCertificationCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Certification Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Certification deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Certification not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this Certification. Because: {ex.Message}!.");
            }
        }
    }
}

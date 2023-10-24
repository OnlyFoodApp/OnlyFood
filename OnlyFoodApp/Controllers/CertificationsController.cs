using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Features.Campaigns.Queries.GetAllCampaigns;
using Application.Features.Certifications.Commands;
using Application.Features.Certifications.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

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
    }
}

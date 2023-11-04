using Application.Common.Response;
using Application.Features.Accounts.Commands.UpdateAccount;
using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Features.Campaigns.Commands.UpdateCampaign;
using Application.Features.Campaigns.Queries.GetAllCampaigns;
using Domain.Exceptions;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;
using System.Net;

namespace OnlyFoodApp.Controllers
{
    public class CampaignsController : ApiControllerBase
    {
        private readonly IMediator _mediator;

        public CampaignsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<Result<List<GetAllCampaignsDto>>>> GetAllCampaignAsync()
        {
            return await _mediator.Send(new GetAllCampaignsQuery());
        }

        [HttpPost]
        public async Task<Result<Guid>> CreateCampaigns(CreateCampaignCommand campaign)
        {
            var a = campaign;
            return await _mediator.Send(campaign);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateCampaignCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Campaign not found!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Campaign updated successfully!.");
            }
            catch (NotFoundException nfEx)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Campaign not found!.");
            }
            catch(Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not update this campaign. Because: { ex.Message }!.");
            }
        }
    }
}

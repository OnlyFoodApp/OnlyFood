using Application.Common.Response;
using Application.Features.Campaigns.Queries.GetCampaignById;
using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Features.Campaigns.Commands.DeleteCampaign;
using Application.Features.Campaigns.Commands.UpdateCampaign;
using Application.Features.Campaigns.Queries.GetAllCampaigns;
using Application.Features.Certifications.Commands.UpdateCertification;
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


        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Result<GetCampaignWithIdDto>>> GetCampaignByIdAsync(String id)
        {
            return await _mediator.Send(new GetCampaignWithIdQuery(Guid.Parse((ReadOnlySpan<char>)id)));
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<Status> Update(Guid id, UpdateCampaignCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Campaign Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Campaign updated successfully!.");
            }
            catch (NotFoundException)
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

        [HttpDelete]
        [Route("{id}")]
        public async Task<Status> Delete(Guid id, DeleteCampaignCommand command)
        {
            if (!id.Equals(command.Id))
            {
                return new Status(HttpStatusCode.BadRequest,
                "Failed",
                "Campaign Id was not match!.");
            }
            try
            {
                await _mediator.Send(command);
                return new Status(HttpStatusCode.OK,
                "Success",
                "Campaign deleted successfully!.");
            }
            catch (NotFoundException)
            {
                return new Status(HttpStatusCode.NotFound,
                "Failed",
                "Campaign not found!.");
            }
            catch (Exception ex)
            {
                return new Status(HttpStatusCode.InternalServerError,
                "Failed",
                $"Can not delete this campaign. Because: {ex.Message}!.");
            }
        }
    }
}

using Application.Features.Campaigns.Commands.CreateCampaign;
using Application.Features.Campaigns.Queries.GetAllCampaigns;
using Domain.Entities;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Shared;

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
        //[HttpGet]
        //[Route("getEarningDataBaseOnCampaign")]
        //public async Task<Result<GetEarningDataBaseOnCampaignDto>> GetEarningDataBaseOnCampaignAsync()
        //{
        //    return await _mediator.Send(new GetEarningDataBaseOnCampaignQuery());
        //}
    }
}

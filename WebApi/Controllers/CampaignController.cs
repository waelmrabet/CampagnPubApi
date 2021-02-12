using AutoMapper;
using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Builders;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CampaignController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ICampaignService _campaignService;
        private readonly IRegionService _regionService;
        private readonly ITownService _townService;

        public CampaignController(ICampaignService campaignService, IRegionService regionService, ITownService townService, IMapper mapper)
        {
            _mapper = mapper;
            _campaignService = campaignService;
            _regionService = regionService;
            _townService = townService;
        }
        
        [HttpPost]
        public bool CreateCompaignStepOne(CampaignCreateDto campaignCreateDto)
        {
            var campaign = CampaignBuilders.BuildCompaign(campaignCreateDto);

            var created = _campaignService.CreateCampaign(campaign, campaignCreateDto.RegionId, campaignCreateDto.TownsIds, campaignCreateDto.BusinessTypesIds, campaignCreateDto.ProductTypeIds);            

            return created;
        }
    }
}

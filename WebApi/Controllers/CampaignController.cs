using AutoMapper;
using BL.Services;
using Core.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
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
        public CampaignController(ICampaignService campaignService, IMapper mapper)
        {
            _mapper = mapper;
            _campaignService = campaignService;
        }

        #region Campaign Managment

        [HttpPost]
        public bool CreateCompaignStepOne(CampaignCreateDto campaignCreateDto)
        {
            var campaign = _mapper.Map<Campaign>(campaignCreateDto);

            var created = _campaignService.CreateCampaign(campaign, campaignCreateDto.RegionId, campaignCreateDto.TownsIds, campaignCreateDto.BusinessTypesIds, campaignCreateDto.ProductTypeIds, campaignCreateDto.CustomerId);

            return created;
        }

        [HttpDelete]
        [Route("{id}")]
        public bool DeleteCampaignById(int id)
        {
            _campaignService.Delete(id);
            _campaignService.Commit();

            return true;
        }

        [HttpGet]
        [Route("{id}")]
        public CampaignReadDto GetCampaignById(int id)
        {
            var campaign = _campaignService.GetCampaignByIdFullData(id);

            var campaignReadDto = _mapper.Map<CampaignReadDto>(campaign);

            return campaignReadDto;
        }

        [HttpGet]
        [Route("GetAllCampaigns")]
        public List<CampaignReadDto> GetAllCampaigns()
        {
            var campaigns = _campaignService.GetAllCampaigns();
            var result = _mapper.Map<List<CampaignReadDto>>(campaigns);

            return result;
        }

        #endregion

        #region Campaign Towns Managment

        [HttpGet]
        [Route("getCampaignTownMap/{campaignId}")]
        public List<DetailsCampaignTownReadDto> GetCampaignTownMap(int campaignId)
        {

            var detailesTownsList = _campaignService.GetListDetailsCampaignTowns(campaignId);
            var result = _mapper.Map<List<DetailsCampaignTownReadDto>>(detailesTownsList);

            return result;
        }

        [HttpDelete]
        [Route("deleteCampaignTown/{campaignId}/{townId}")]
        public CampaignReadDto DeleteCampaignTown(int campaignId, int townId)
        {
            var campaign = _campaignService.DeleteCampaignTown(campaignId, townId);
            var result = _mapper.Map<CampaignReadDto>(campaign);

            return result;
        }

        [HttpGet]
        [Route("addCampaignTown/{campaignId}/{townId}")]

        public CampaignReadDto AddCampaignTown(int campaignId, int townId)
        {
            var campaign = _campaignService.AddCampaignTown(campaignId, townId);
            var result = _mapper.Map<CampaignReadDto>(campaign);

            return result;
        }



        #endregion

        #region Campaign Products Managment

        [HttpDelete]
        [Route("deleteCamapaignProduct/{campaignId}/{productTypeId}")]
        public CampaignReadDto DeleteCampaignProduct(int campaignId, int productTypeId)
        {
            var campaign = _campaignService.DeleteCampaignProduct(campaignId, productTypeId);
            var campaignDto = _mapper.Map<CampaignReadDto>(campaign);

            return campaignDto;
        }

        [HttpPut]
        [Route("updateCamapaignProduct/{campaignId}/")]
        public CampaignReadDto UpdateCampaignProduct(int campaignId, ProductUpdateDto productUpdateDto)
        {

            var campaign = _campaignService.UpdateCampaignProduct(campaignId, productUpdateDto.ProductTypeId, productUpdateDto.FinalNbrProductPerBusiness, productUpdateDto.FinalPrice);
            var result = _mapper.Map<CampaignReadDto>(campaign);

            return result;
        }

        [HttpGet]
        [Route("addCamapaignProduct/{campaignId}/{productTypeId}")]
        public CampaignReadDto AddCampaignProduct(int campaignId, int productTypeId)
        {
            var campaign = _campaignService.AddCampaignProduct(campaignId, productTypeId);

            var result = _mapper.Map<CampaignReadDto>(campaign);

            return result;
        }

        #endregion

        #region Campaign Businesses and Business Types Managment

        [HttpDelete]
        [Route("deleteCampaignBusinessType/{campaignId}/{BusinessTypeMapCode}")]
        public CampaignReadDto DeleteCampaignBusinessType(int campaignId, string BusinessTypeMapCode)
        {
            var campaign = _campaignService.DeleteCampaignBusinessType(campaignId, BusinessTypeMapCode);
            var campaignDto = _mapper.Map<CampaignReadDto>(campaign);

            return campaignDto;
        }


        [HttpGet]
        [Route("addCampaignBusinessType/{campaignId}/{businessTypeMapCode}")]
        public CampaignReadDto AddCampaignBusinessType(int campaignId, string businessTypeMapCode)
        {
            var campaign = _campaignService.AddCampaignBusinessType(campaignId, businessTypeMapCode);
            var result = _mapper.Map<CampaignReadDto>(campaign);

            return result;
        }


        #endregion

        #region Campaign Global Params Managment

        [HttpPut]
        [Route("updateCampaignGlobalParams/{campaignId}/")]
        public CampaignReadDto UpdateCampaignGlobalParams(int campaignId, CampaignGlobalParmsUpdateDto globalParmsUpdateDto)
        {
            var campaignModif = new Campaign()
            {
                Title = globalParmsUpdateDto.Title,
                Goal = globalParmsUpdateDto.Goal,
                ForecastBudget = globalParmsUpdateDto.ForecastBudget,
                ExecutionDate = globalParmsUpdateDto.ExecutionDate,
                PenetraionRate = globalParmsUpdateDto.PenetrationRate,
                Description = globalParmsUpdateDto.Description
            };


            var campaign = _campaignService.UpdateCampaignGlobalParameters(campaignId, campaignModif);
            var result = _mapper.Map<CampaignReadDto>(campaign);

            return result;
        }

        #endregion

    }
}

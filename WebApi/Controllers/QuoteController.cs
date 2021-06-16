using AutoMapper;
using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;
        private readonly IMapper _mapper;

        public QuoteController(IQuoteService quoteService, IMapper mapper)
        {
            this._quoteService = quoteService;
            this._mapper = mapper;
        }

        [HttpGet]
        [Route("{userRoleId}/{customerId}")]
        public List<QuoteReadDto> GetDevisByRoleUser(int userRoleId, int customerId)
        {
            var quotes =  this._quoteService.GetQuotesByRoleUser(userRoleId, customerId);
            var result = _mapper.Map<List<QuoteReadDto>>(quotes);

            return result;
        }

        [HttpGet]
        [Route("GenerateCampaignQuote/{campaignId}")]
        public void GenerateCampaignQuote(int campaignId)
        {
             this._quoteService.CreateDevis(campaignId);
        }

        [HttpGet]
        [Route("{devisId}")]
        public QuoteReadDto GetDevisById(int devisId)
        {            
            var devis = this._quoteService.GetQuoteFullDataById(devisId);
            var result = this._mapper.Map<QuoteReadDto>(devis);

            return result;
        }
    
    }
}
 
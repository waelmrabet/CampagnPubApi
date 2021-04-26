using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuoteController : ControllerBase
    {
        private readonly IQuoteService _quoteService;

        public QuoteController(IQuoteService quoteService)
        {
            this._quoteService = quoteService;
        }

        [HttpGet]
        [Route("GenerateCampaignQuote/{campaignId}")]
        public void GenerateCampaignQuote(int campaignId)
        {
             this._quoteService.CreateDevis(campaignId);
        }
    }
}
 
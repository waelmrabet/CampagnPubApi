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
    public class TownController : ControllerBase
    {
        private readonly ITownService _townService;
        private readonly IMapper _mapper;

        public TownController(ITownService townService, IMapper mapper)
        {
            _townService = townService;
            _mapper = mapper;
        }

        [HttpGet]
        [Route("fullEntity/{fullEntity}")]
        public List<TownDto> getAllTowns(bool fullEntity)
        {
            var townsList = fullEntity ? _townService.GetFullTowns() :  _townService.GetAll().ToList();
            var result = _mapper.Map<List<TownDto>>(townsList);

            return result;
        }

        [HttpGet]
        [Route("TownsByRegion/{regionId}/{fullEntity}")]        
        public List<TownDto> getTownByRegion(int regionId, bool fullEntity)
        {
            var listTowns = _townService.GetTownsByRegion(regionId, fullEntity);
            var result = _mapper.Map<List<TownDto>>(listTowns);

            return result;
        }
        


    }
}

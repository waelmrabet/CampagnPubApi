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
    public class BusinessTypeController : ControllerBase
    {
        private readonly IBusninessTypeService _businessTypeService;
        private readonly IMapper _mapper;


        
        public BusinessTypeController(IBusninessTypeService  businessTypeService, IMapper mapper)
        {
            _businessTypeService = businessTypeService;
            _mapper = mapper;
        }

        [HttpGet]
        public List<BusinessTypeDto> GetAllBusinessTypes()
        {
            var list = _businessTypeService.GetAll().ToList();
            var result = _mapper.Map<List<BusinessTypeDto>>(list);

            return result;
        }
    }
}

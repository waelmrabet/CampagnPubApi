using AutoMapper;
using BL.Services;
using Core.Models;
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
    public class ProductTypeController : ControllerBase
    {

        private readonly IMapper _mapper;
        private IProductTypeService _productTypeService;

        public ProductTypeController(IMapper mapper, IProductTypeService productTypeService)
        {
            _mapper = mapper;
            _productTypeService = productTypeService;
        }

        [HttpPost]
        public ProductTypeReadDto AddProductType(ProductTypeCreateDto productTypeCreateDto)
        {
            var productTypeModel = _mapper.Map<ProductType>(productTypeCreateDto);

            _productTypeService.Insert(productTypeModel);
            _productTypeService.Commit();
            var productTypeReadDto = _mapper.Map<ProductTypeReadDto>(productTypeModel);

            return productTypeReadDto;
        }

        [HttpGet]
        public List<ProductTypeReadDto> GetAllProductTypes()
        {
            var productTypes = _productTypeService.GetAll().ToList();
            var products = _mapper.Map<List<ProductTypeReadDto>>(productTypes);
            return products;
        }



        /*
        [HttpGet]
        public List<UserReadDto> GetAllUsers()
        {
            var users = _productTypeService.GetAll().ToList();
            var userList = _mapper.Map<List<UserReadDto>>(users);
            return userList;
        }

        [HttpGet]
        [Route("{id}")]
        public UserReadDto GetUserById(int id)
        {
            var user = _productTypeService.GetById(id);
            var userReadDto = _mapper.Map<UserReadDto>(user);

            return userReadDto;
        }

        [HttpPut]
        [Route("{id}")]
        public CustomerReadDto UpdateCustomer(int id, CustomerReadDto customerReadDto)
        {
            var userModel = _productTypeService.GetById(id);
            _mapper.Map(customerReadDto, userModel);
            _productTypeService.Commit();

            return customerReadDto;
        }


        */

    }
}

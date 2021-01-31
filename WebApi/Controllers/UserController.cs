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
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;

        public UserController(IMapper mapper, IUserService  userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpPost]
        public UserReadDto AddUser(UserCreateDto userCreateDto)
        {
            var userModel = _mapper.Map<User>(userCreateDto);

            _userService.Insert(userModel);
            _userService.Commit();
            var userReadDto = _mapper.Map<UserReadDto>(userModel);

            return userReadDto;
        }

        [HttpGet]
        public List<UserReadDto> GetAllUsers()
        {
            var users = _userService.GetAll().ToList();
            var userList = _mapper.Map<List<UserReadDto>>(users);
            return userList;  
        }

        [HttpGet]
        [Route("{id}")]
        public UserReadDto GetUserById(int id)
        {
            var user = _userService.GetById(id);
            var userReadDto = _mapper.Map<UserReadDto>(user);

            return userReadDto;
        }

        [HttpPut]
        [Route("{id}")]
        public CustomerReadDto UpdateCustomer(int id, CustomerReadDto customerReadDto)
        {
            var userModel = _userService.GetById(id);
            _mapper.Map(customerReadDto, userModel);
            _userService.Commit();

            return customerReadDto;           
        }


    }
}

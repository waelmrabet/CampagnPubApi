using AutoMapper;
using BL.Services;
using Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using WebApi.Dtos;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private IUserService _userService;
        private IRoleService _roleService;

        public UserController(IMapper mapper, IUserService  userService, IRoleService roleService)
        {
            _mapper = mapper;
            _userService = userService;
            _roleService = roleService;
        }

        [HttpGet]
        [Route("MenusByProfile/{roleId}")]
        public List<MenuDto> GetMenusProfileAdmin(int roleId)
        {
            var list = this._roleService.GetMenusByRoleId(roleId).ToList();
            var result = _mapper.Map<List<MenuDto>>(list);

            return result;
        }


        [HttpPost]
        [Route("Login")]
        public AuthenticatedUserDto Login(AuthenticationSubject identity)
        {
            // this is gonna be changed after implementation of dot net security module
            var id = 1;
            var user = _userService.GetById(id);

            var menus = _roleService.GetMenusByRoleId(user.RoleId).ToList();
            var menusDto = _mapper.Map<List<MenuDto>>(menus);

            var result = _mapper.Map<AuthenticatedUserDto>(user);
            result.Menus = menusDto;

            return result;

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

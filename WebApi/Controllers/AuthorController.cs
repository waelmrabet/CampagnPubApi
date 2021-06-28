using AutoMapper;
using BL.Services;
using BL.Services.Impl;
using Core.Models;
using Data.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Controllers
{

    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorController : ControllerBase
    {
        private readonly IAuthorService _authorService;
        private readonly IMapper _mapper;

        public AuthorController(IAuthorService authorService, IMapper mapper)
        {
            _authorService = authorService;
            _mapper = mapper;
        }

        [HttpGet]
        public IEnumerable<AuthorReadDto> Get()
        {
            var list = _mapper.Map<IEnumerable<AuthorReadDto>>(_authorService.GetAll());
            return list;
        }

        [HttpPost]
        public AuthorReadDto AddAuthor(AuthorCreateDto authorCreateDto)
        {
            var authorModel = _mapper.Map<Author>(authorCreateDto);
            _authorService.Insert(authorModel);
            _authorService.Commit();
            var authorReadDto = _mapper.Map<AuthorReadDto>(authorModel);

            return authorReadDto;
        }

        [HttpDelete]
        [Route("{id}")]
        public void DeleteAuthor(int id)
        {
            _authorService.Delete(id);
            _authorService.Commit();
        }

        [HttpPut]
        [Route("{id}")]
        public AuthorReadDto UpdateAuthor(int id, AuthorCreateDto authorCreateDto)
        {
            var authorModel = _authorService.GetById(id);
            _mapper.Map(authorCreateDto, authorModel);
            _authorService.Update(authorModel);
            _authorService.Commit();

            var authorReadDto = _mapper.Map<AuthorReadDto>(authorModel);
            return authorReadDto;
        }



    }
}

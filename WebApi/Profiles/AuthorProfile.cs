using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class AuthorProfile : Profile
    {
        public AuthorProfile()
        {
            // ExterneModel (dto) => InternModel(Entity)
            CreateMap<AuthorCreateDto, Author>();
            CreateMap<Author, AuthorReadDto>();
        }
    }
}

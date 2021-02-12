using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class RegionProfile : Profile
    {
        public RegionProfile()
        {
            // extern to intern
            CreateMap<RegionDto, Region>();
            // intern to extern
            CreateMap<Region, RegionDto>();
        }
    }
}

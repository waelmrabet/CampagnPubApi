﻿using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class BusinessTypeProfile : Profile
    {
        public BusinessTypeProfile()
        {
            // intern to extern
            CreateMap<BusinessType, BusinessTypeDto>();
           
            // extern to intern
            CreateMap<BusinessTypeDto, BusinessType>();
        }
    }
}

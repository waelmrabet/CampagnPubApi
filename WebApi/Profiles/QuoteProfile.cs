﻿using AutoMapper;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;

namespace WebApi.Profiles
{
    public class QuoteProfile: Profile
    {
        public QuoteProfile()
        {
            // interne to extern model
            CreateMap<Quote, QuoteReadDto>();
        }
    }
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class BusinessTypeDto : BaseDto
    {
        public string Code { get; set; }
        public string MapCode { get; set; }        
    }
}

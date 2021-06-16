﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class AuthenticationSubject
    {
        public string UserName { get; set; }
        public string Password { get; set; }
        public int ClientId { get; set; }
    }
}

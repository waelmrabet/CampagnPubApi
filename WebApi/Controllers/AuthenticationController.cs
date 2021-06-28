using BL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApi.Dtos;
using WebApi.Helpers;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ControllerBase
    {       
        private readonly IAuthenticationService _authService;
        private readonly IStringCryptorDecryptor _stringCryptorDecryptor;

        public AuthenticationController(IAuthenticationService authenticationService, IStringCryptorDecryptor stringCryptorDecryptor)
        {           
            _authService = authenticationService;
            _stringCryptorDecryptor = stringCryptorDecryptor;
        }

        [HttpPost("authenticate")]
        public IActionResult Authenticate(AuthenticateRequest model)
        {
            var response = _authService.Authenticate(model);

            if (response == null)
                return BadRequest(new { message = "Username or password is incorrect" });

            return Ok(response);
        }  

    }
}

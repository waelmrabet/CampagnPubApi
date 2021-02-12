using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Dtos
{
    public class UserReadDto : BaseDto
    {
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Matricule { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public int Role { get; set; }
        public int ClientId { get; set; }
        public string Password { get; set; }
    }
}

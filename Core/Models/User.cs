using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class User : BaseEntity
    {
        // properties        
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string Matricule { get; set; }
        public string Email { get; set; }
        public string TelNumber { get; set; }
        public int Role { get; set; }
        public int ClientId { get; set; }
        public string Password { get; set; }

        // navigation properties
        public virtual ICollection<Campaign> Compagns { get; set; }
        public virtual ICollection<Customer> Customers { get; set; }


    }
}

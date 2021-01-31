using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Photo : BaseEntity
    {
        // navigation 
        public string ImageName { get; set; }
        public string Description { get; set; }

        // navigation properties
        public CompagnBusiness CompagnBusinesse { get; set; }
    }
}

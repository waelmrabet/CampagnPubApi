using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Book : BaseEntity
    {
        public String Title { get; set; }
        public DateTime Year { get; set; }
    }
}

﻿using Core.CompelxeTypes;
using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Customer : BaseEntity
    {
        // properties
        public string Name { get; set; }
        public string TaxIdNumber { get; set; }
        public Address Address { get; set; }
        public string Mail { get; set; }
        public string TelNumber { get; set; }

        // navigation properties        
        public virtual ICollection<Compagn> Compagns { get; set; }

        // constructors
        public Customer()
        {
            this.Compagns = new HashSet<Compagn>();
        }


    }
}

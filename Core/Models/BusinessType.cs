﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class BusinessType : BaseEntity
    {
        // properties
        public string Code { get; set; }
        public string MapCode { get; set; }    

        // navigation properties
        public virtual ICollection<CompagnBusiness> CompagnBusinesses { get; set; }

    }
}

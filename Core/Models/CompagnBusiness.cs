using Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
    public class CompagnBusiness
    {
        // properties
        public int CompagnId { get; set; }       
        public int BusinessId { get; set; }
        public BusinessState State { get; set; }

        // navigation properties
        public BusinessType BusinessType { get; set; }
        public Compagn Compagn { get; set; }
        public virtual ICollection<Photo> Photos { get; set; }

    }
}

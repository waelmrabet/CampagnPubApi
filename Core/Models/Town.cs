using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{    
    public class Town : BaseEntity
    {  
        public string City { get; set; }
        public string PostalCode { get; set; }
        //public string Region { get; set; }
        public string Departement { get; set; }
        public string Canton { get; set; }
        public string Borough { get; set; }
        public float Lat { get; set; }
        public float Lng { get; set; }

        // Navigation Properties
        [ForeignKey(nameof(Region))]
        public int RegionId { get; set; }
        public virtual Region Region { get; set; }
        public virtual ICollection<Compagn> Compagns { get; set; }

        public Town()
        {           
            this.Compagns = new HashSet<Compagn>();
        }

    }
}
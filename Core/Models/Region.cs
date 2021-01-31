using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Models
{
    public class Region : BaseEntity
    {        
        public string Name { get; set; }
        // navigation properties
        public virtual ICollection<Town> Towns { get; set; }
        public Region()
        {
            this.Towns = new HashSet<Town>();
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
    public class Compagn : BaseEntity
    {
        // properties
        public string Title { get; set; }
        public string Objectif { get; set; }
        public float BudgetPrevisionnel { get; set; }
        public int PenetraionRate { get; set; }

        public string Description { get; set; }
        public float TotalCost { get; set; }
        public DateTime ExecutionDate { get; set; }

        // navigation properties        

        public Region Region { get; set; }
        public Customer Customer { get; set; }
        public Product Product { get; set; }
        public virtual ICollection<CompagnBusiness> CompagnBusinesses { get; set; }
        public virtual ICollection<Town> Towns { get; set; }


        public Compagn()
        {          
            this.CompagnBusinesses = new HashSet<CompagnBusiness>();
            this.Towns = new HashSet<Town>();
        }

    }
}

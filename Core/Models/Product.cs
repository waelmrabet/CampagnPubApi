using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Models
{
       
    public class Product 
    {

        [ForeignKey(nameof(ProductType))]
        public int ProductId { get; set; }        
        public int NbrProductPerBusiness { get; set; }
        public ProductType ProductType { get; set; }    

    }
}

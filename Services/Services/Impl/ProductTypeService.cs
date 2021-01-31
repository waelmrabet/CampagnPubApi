using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class ProductTypeService : ServicePattern<ProductType>, IProductTypeService
    {
        private readonly IProductTypeRepository _productTypeRepo; 
        public ProductTypeService(IProductTypeRepository productTypeRepo) : base(productTypeRepo)
        {
            _productTypeRepo = productTypeRepo;
        }
    }
}

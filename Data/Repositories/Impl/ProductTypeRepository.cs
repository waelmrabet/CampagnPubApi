using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Impl
{
    public class ProductTypeRepository : Repository<ProductType>, IProductTypeRepository, IRepository<ProductType>
    {
        public ProductTypeRepository(MyDataBaseContext context) : base(context) { }
    }
}

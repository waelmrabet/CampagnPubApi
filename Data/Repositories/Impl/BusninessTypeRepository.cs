using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Impl
{
    public class BusninessTypeRepository : Repository<BusinessType>, IBusninessTypeRepository
    {
        public BusninessTypeRepository(MyDataBaseContext ctx): base(ctx) { }        
    }
}

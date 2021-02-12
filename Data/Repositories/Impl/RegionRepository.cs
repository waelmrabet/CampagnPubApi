using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Impl
{
    public class RegionRepository : Repository<Region>, IRegionRepository
    {
        public RegionRepository(MyDataBaseContext context) : base(context) { }      
    }
}

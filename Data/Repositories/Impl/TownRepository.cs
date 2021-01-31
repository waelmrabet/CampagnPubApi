using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories.Impl
{
    public class TownRepository: Repository<Town>, ITownRepository
    {       
        public TownRepository(MyDataBaseContext dbCtx) : base(dbCtx) { }

        public List<Town> GetFullTowns()
        {
            return context.Set<Town>().Include(x => x.Region).ToList();           
        }
    }
}

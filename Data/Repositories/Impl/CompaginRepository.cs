using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Impl
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository (MyDataBaseContext ctx): base(ctx)
        { }
    }
}

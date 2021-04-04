using Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data.Repositories.Impl
{
    public class CampaignRepository : Repository<Campaign>, ICampaignRepository
    {
        public CampaignRepository(MyDataBaseContext ctx) : base(ctx)
        { }

        public List<Campaign> GetAllCampaigns()
        {
            var campaigns = Entities
                .Include(x => x.Customer)
                .Include(x=> x.Region)
                .ToList();

            return campaigns;
        }

        public Campaign GetCampaignFullData(int idCampaign)
        {
            var campaign = base.Entities
                .Where(x => x.Id == idCampaign)
                .Include(x => x.Customer)
                .Include(x => x.Region)
                .Include(x => x.CampaignBusinessTypes)
                .Include(x => x.CampaignBusinesses)
                .Include(x => x.CampaignTowns)
                .Include(x => x.CampaignProducts)
                .Include(x => x.CampaignProducts).ThenInclude(pt => pt.ProductType);                
                
            return campaign.FirstOrDefault();

        }
    }
}

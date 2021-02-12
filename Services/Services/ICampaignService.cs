using BL.ServicePattern;
using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services
{
    public interface ICampaignService : IServicePattern<Campaign>
    {
        bool CreateCampaign(Campaign campaign, int regionId, List<int> townsIds, List<string> businessTypesIds, List<int> productTypeIds);
    }
}

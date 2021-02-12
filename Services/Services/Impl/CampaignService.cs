using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class CampaignService : ServicePattern<Campaign>, ICampaignService
    {
        private readonly ICampaignRepository _campaignRepo;
        private readonly IRegionRepository _regionRepo;
        private readonly ITownRepository _townRepo;
        private readonly IBusninessTypeRepository _businessTypeRepo;
        private readonly IProductTypeRepository _productTypeRepo;

        public CampaignService(ICampaignRepository campaignReporepo, IRegionRepository regionRepo, 
                ITownRepository townRepo, IBusninessTypeRepository businessTypeRepo, IProductTypeRepository productTypeRepo): base(campaignReporepo)
        {
            _campaignRepo = campaignReporepo;
            _regionRepo = regionRepo;
            _townRepo = townRepo;
            _businessTypeRepo = businessTypeRepo;
            _productTypeRepo = productTypeRepo;
        }

        public bool CreateCampaign(Campaign campaign, int regionId, List<int> townsIds, List<string> businessTypesIds, List<int> productTypeIds)
        {
            try
            {
                // set compagn parameters
                campaign.Region = _regionRepo.GetById(regionId);
                campaign.CampaignTowns = _townRepo.GetTownsInListIds(townsIds);

                // à voir plus tard
                //campaign.CampaignBusinessTypes = _businessTypeRepo.GetBusinessInListMapCodes(businessTypesIds);

                Insert(campaign);

                // set product List 
                var compaignProducts = new HashSet<Product>();
                var selectedProductTypes = _productTypeRepo.GetproductTypeInListIds(productTypeIds);

                foreach (var productType in selectedProductTypes)
                {
                    var product = new Product();
                    
                    product.NbrProductPerBusiness = 1;
                    product.ProductType = productType;
                    compaignProducts.Add(product);
                }
                    
                Commit();
                return true;
            }
            catch(Exception ex)
            {
                RollBack();
                var msg = ex.Message;
                return false;
            }
            

            

        }
    }
}

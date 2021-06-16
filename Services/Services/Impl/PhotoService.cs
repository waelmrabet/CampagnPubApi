using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class PhotoService: ServicePattern<Photo>, IPhotoService
    {
        public PhotoService(IPhotoRepository photoRepo): base(photoRepo)
        {

        }

        public void AddListPhotos(CampaignBusiness campaignBusiness, List<string> photosNames)
        {           
            // add list campaignBusiness photos
            foreach(var name in photosNames)
            {
                var photo = new Photo()
                {
                    ImageName = name,
                    CampaignBusiness = campaignBusiness
                };

                base.Insert(photo);
                Commit();
            }           
        }
    }
}

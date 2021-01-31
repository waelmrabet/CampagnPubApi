using BL.ServicePattern;
using Core.Models;
using Data.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Services.Impl
{
    public class BusninessTypeService : ServicePattern<BusinessType>, IBusninessTypeService
    {
        public BusninessTypeService(IBusninessTypeRepository businessTypeRepo): base(businessTypeRepo) { }    
    }
}

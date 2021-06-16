using Core.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Repositories.Impl
{
    public class PhotoRepository: Repository<Photo>, IPhotoRepository
    {
        public PhotoRepository(MyDataBaseContext ctx): base(ctx) { }

    }
}

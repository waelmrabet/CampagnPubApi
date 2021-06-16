using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utils
{
    public interface IFilesService
    {
        public string CreateCampaignFilesDirectoryIfNotExist(int campaignId, string parentDirectory);
        public string UploadFile(string path, IFormFile file);
        public List<string> UploadListFiles(List<IFormFile> files, int campaignId);

    }
}

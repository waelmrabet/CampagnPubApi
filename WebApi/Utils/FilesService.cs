using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Utils
{
    public class FilesService : IFilesService
    {
        private readonly IConfiguration _configuration;

        public FilesService(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        
        public string CreateCampaignFilesDirectoryIfNotExist(int campaignId, string parentDirectory)
        {
            var folderName = campaignId + "_CampaignBusinessPhotos" ;
            var folderPath = Path.Combine(parentDirectory, folderName);

            // Determine whether the directory exists.
            if (!Directory.Exists(folderPath))           
                Directory.CreateDirectory(folderPath);                 
                
            return folderPath;         

        }

        public List<string> UploadListFiles(List<IFormFile> files, int campaignId)
        {       
            var parentDirectory = _configuration.GetSection("BusinessPhotos").Value;
            var filePath = CreateCampaignFilesDirectoryIfNotExist(campaignId, parentDirectory);

            var listfileNames = new List<string>();
            foreach (var file in files)
            {
                var fileName = UploadFile(filePath, file);

                if (!String.IsNullOrEmpty(fileName))
                    listfileNames.Add(fileName);

            }

            return listfileNames;            
        }

        public string UploadFile(string path, IFormFile file)
        {
            var filePath = Path.Combine(path, file.FileName);

            // if Exists delete
            if (File.Exists(filePath))
                File.Delete(filePath);

            file.CopyTo(new FileStream(filePath, FileMode.Create));            

            return file.FileName;
        }      

        
    }
}

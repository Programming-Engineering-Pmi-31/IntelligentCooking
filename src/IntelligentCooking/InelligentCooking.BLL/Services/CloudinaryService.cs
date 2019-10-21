using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using InelligentCooking.BLL.Interfaces;
using InelligentCooking.BLL.Settings;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;

namespace InelligentCooking.BLL.Services
{
    public class CloudinaryService : IImageService
    {
        private readonly Account _cloudinaryAccount;

        public CloudinaryService(IOptions<CloudinarySettings> cloudinarySettings)
        {
            var settings = cloudinarySettings.Value;
            _cloudinaryAccount = new Account(
                settings.Cloud,
                settings.ApiKey,
                settings.Secret);
        }

        public async Task<string> UploadImageAsync(IFormFile file)
        {
            var uploadParams = new ImageUploadParams
            {
                File = new FileDescription(file.FileName, file.OpenReadStream()),
                UseFilename = true,
                UniqueFilename = false,
                Overwrite = true
            };

            var res = await UploadImageAsync(uploadParams);

            return res.SecureUri.ToString();
        }


        private Task<ImageUploadResult> UploadImageAsync(ImageUploadParams @params)
        {
            var cloudinary = new Cloudinary(_cloudinaryAccount);

            return Task.Factory.StartNew(
                () => cloudinary.Upload(@params));
        }

        public async Task<IEnumerable<string>> UploadRangeAsync(IEnumerable<IFormFile> files)
        {
            var urls = new List<string>();

            foreach(var file in files)
            {
                urls.Add(await UploadImageAsync(file));
            }

            return urls;
        }
    }
}

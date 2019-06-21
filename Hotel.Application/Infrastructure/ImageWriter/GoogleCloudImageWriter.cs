using Google.Apis.Auth.OAuth2;
using Google.Cloud.Storage.V1;
using Hotel.Application.Interfaces.ImageWriter;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Options;
using System;
using System.IO;
using System.Threading.Tasks;

namespace Hotel.Application.Infrastructure.ImageWriter
{
    public class GoogleCloudImageWriter : IImageWriter
    {
        private readonly string bucketName;
        private readonly StorageClient storageClient;

        public GoogleCloudImageWriter(IOptions<SettingsModel> settings)
        {
            bucketName = settings.Value.GoogleCloudStorageName;
            var credential = GoogleCredential.FromFile(Directory.GetCurrentDirectory() + settings.Value.GoogleCloudStorageCredFile);
            storageClient = StorageClient.Create(credential);
        }

        public async Task<string> UploadImage(IFormFile image)
        {
            var imageAcl = PredefinedObjectAcl.PublicRead;

            var imageObject = await storageClient.UploadObjectAsync(
                bucket: bucketName,
                objectName: Guid.NewGuid().ToString(),
                contentType: image.ContentType,
                source: image.OpenReadStream(),
                options: new UploadObjectOptions { PredefinedAcl = imageAcl }
            );

            return imageObject.Name;
        }


        public async Task RemoveImage(string fileName)
        {
            try
            {
                await storageClient.DeleteObjectAsync(bucketName, fileName);
            }
            catch (Google.GoogleApiException exception)
            {
                if (exception.Error.Code != 404)
                    throw;
            }
        }
    }
}

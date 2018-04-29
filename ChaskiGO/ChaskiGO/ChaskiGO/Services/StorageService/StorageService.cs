using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using Microsoft.WindowsAzure.Storage;

namespace ChaskiGO.Services.StorageService
{
    public class StorageService : IStorageService
    {
        public async Task<string> UploadImage(Stream image)
        {
            var account = CloudStorageAccount.Parse("DefaultEndpointsProtocol=https;AccountName=ukuparentsapp;AccountKey=en4yoYhuX/rWTcAwvdf4cCZJCOWqDkF6na9iiu9lK3/uqznXh7B82uq+qkJfQVkk/krwk65O17F3PTMnIDNjmg==;EndpointSuffix=core.windows.net");
            var blobClient = account.CreateCloudBlobClient();
            var container = blobClient.GetContainerReference("ukucontainer");

            var uniqueName = Guid.NewGuid().ToString();
            var blockBlob = container.GetBlockBlobReference($"{uniqueName}.jpg");
            await blockBlob.UploadFromStreamAsync(image);

            var pictureUrl = blockBlob.Uri.OriginalString;

            return pictureUrl;
        }
    }
}

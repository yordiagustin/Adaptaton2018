using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media;
using Plugin.Media.Abstractions;

namespace ChaskiGO.Services.MediaService
{
    public class MediaService : IMediaService
    {
        public async Task<MediaFile> TakePicture()
        {
            await CrossMedia.Current.Initialize();
            var name = Guid.NewGuid().ToString();
            var picture = await CrossMedia.Current.TakePhotoAsync(new StoreCameraMediaOptions()
            {
                Directory = "UKU",
                Name = name,
                PhotoSize = PhotoSize.Small
            });
            return picture;
        }

        public async Task<MediaFile> PickPicture()
        {
            await CrossMedia.Current.Initialize();

            var picture = await Plugin.Media.CrossMedia.Current.PickPhotoAsync(new Plugin.Media.Abstractions.PickMediaOptions());
            return picture;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Plugin.Media.Abstractions;

namespace ChaskiGO.Services.MediaService
{
    public interface IMediaService
    {
        Task<MediaFile> TakePicture();
        Task<MediaFile> PickPicture();
    }
}

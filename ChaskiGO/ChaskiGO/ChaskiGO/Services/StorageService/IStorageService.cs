using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace ChaskiGO.Services.StorageService
{
    public interface IStorageService
    {
        Task<string> UploadImage(Stream image);
    }
}

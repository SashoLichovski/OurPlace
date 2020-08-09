using Microsoft.AspNetCore.Http;
using OurPlace.Data;
using System.Collections.Generic;
using System.Drawing;

namespace OurPlace.Services.Interfaces
{
    public interface IImageService
    {
        void Create(byte[] image, string userId);
        byte[] Upload(Image image);
        Image FormFileToImage(IFormFile file);
        void AddImage(Image image, string userId);
        List<UserImage> GetUserPhotos(string userId);
    }
}

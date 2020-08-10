using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IImageRepository
    {
        void Add(UserImage newImage);
        List<UserImage> GetUserPhotos(string userId);
        byte[] GetByteArrById(int imageId);
        UserImage GetById(int imageId);
        void Delete(UserImage image);
    }
}

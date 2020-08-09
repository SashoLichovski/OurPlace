using System.Drawing;

namespace OurPlace.Services.Interfaces
{
    public interface IImageService
    {
        void Create(byte[] image, string userId);
        byte[] Upload(Image image);
    }
}

using LazZiya.ImageResize;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace OurPlace.Services
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepo;

        public ImageService(IImageRepository imageRepo)
        {
            this.imageRepo = imageRepo;
        }

        public void Create(byte[] image, string userId)
        {
            var newImage = new UserImage()
            {
                Image = image,
                UserId = userId,
                DateUploaded = DateTime.Now
            };

            imageRepo.Add(newImage);
        }

        public byte[] Upload(Image image)
        {
            var scaleImage = ImageResize.ScaleByWidth(image, 700);
            byte[] convertedImage = (byte[])(new ImageConverter()).ConvertTo(scaleImage, typeof(byte[]));
            return convertedImage;
        }
    }
}

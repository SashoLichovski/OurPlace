using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
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

        public Image FormFileToImage(IFormFile file)
        {
            var memoryStream = new MemoryStream();
            file.CopyTo(memoryStream);
            var image = Image.FromStream(memoryStream);
            return image;
        }

        public byte[] Upload(Image image)
        {
            var scaleImage = ImageResize.ScaleByWidth(image, 400);
            byte[] convertedImage = (byte[])(new ImageConverter()).ConvertTo(scaleImage, typeof(byte[]));
            return convertedImage;
        }

        public void AddImage(Image image, string userId)
        {
            var convertedImage = Upload(image);
            Create(convertedImage, userId);
        }

        public List<UserImage> GetUserPhotos(string userId)
        {
            return imageRepo.GetUserPhotos(userId);
        }

        public Response UploadError()
        {
            return new Response
            {
                Error = "Please choose file before submitting"
            };
        }
    }
}

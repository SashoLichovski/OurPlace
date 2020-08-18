using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Common;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace OurPlace.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepo;
        private readonly IImageService imageService;

        public PostService(IPostRepository postRepo, IImageService imageService)
        {
            this.postRepo = postRepo;
            this.imageService = imageService;
        }

        public void Create(string userId, IFormFile image, string message)
        {
            var newPost = new Post()
            {
                UserId = userId,
                Message = message,
                DatePosted = DateTime.Now
            };
            if (image != null)
            {
                var toImage = imageService.FormFileToImage(image);
                var scaledImage = ImageResize.ScaleByWidth(toImage, 300);
                newPost.Image = (byte[])(new ImageConverter()).ConvertTo(scaledImage, typeof(byte[]));
            }
            postRepo.Add(newPost);
        }

        public List<Post> GetAll(string userId)
        {
            return postRepo.GetAll(userId);
        }
    }
}

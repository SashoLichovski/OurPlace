using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Common;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace OurPlace.Services
{
    public class PostService : IPostService
    {
        private readonly IPostRepository postRepo;
        private readonly IImageService imageService;
        private readonly IFriendService friendService;

        public PostService(IPostRepository postRepo, IImageService imageService, IFriendService friendService)
        {
            this.postRepo = postRepo;
            this.imageService = imageService;
            this.friendService = friendService;
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

        public List<Post> GetAllForHomePage(string userId)
        {
            List<string> friendIds = friendService.GetAll(userId)
                .Select(x => x.FriendId)
                .ToList();
            friendIds.Add(userId);

            List<Post> dbPosts = postRepo.GetAllForHomePage(friendIds)
                .ToList();

            return dbPosts;
        }

        public List<Post> GetAllForTimeline(string userId)
        {
            return postRepo.GetAllForTimeline(userId);
        }

        public Post GetById(int postId)
        {
            return postRepo.GetById(postId);
        }
    }
}

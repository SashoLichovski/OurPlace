using Microsoft.EntityFrameworkCore;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Repositories
{
    public class ImageRepository : IImageRepository
    {
        private readonly ApplicationDbContext context;

        public ImageRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(UserImage newImage)
        {
            context.UserImages.Add(newImage);
            context.SaveChanges();
        }

        public void Delete(UserImage image)
        {
            context.UserImages.Remove(image);
            context.SaveChanges();
        }

        public UserImage GetById(int imageId)
        {
            return context.UserImages.FirstOrDefault(x => x.Id.Equals(imageId));
        }

        public byte[] GetByteArrById(int imageId)
        {
            return context.UserImages.FirstOrDefault(x => x.Id.Equals(imageId)).Image;
        }

        public List<UserImage> GetUserPhotos(string userId)
        {
            return context.UserImages
                .Where(x => x.UserId.Equals(userId))
                .Include(x => x.User)
                .Include(x => x.Likes)
                    .ThenInclude(x => x.User)
                .OrderByDescending(x => x.DateUploaded)
                .ToList();
        }
    }
}

﻿using Microsoft.EntityFrameworkCore;
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

        public List<UserImage> GetUserPhotos(string userId)
        {
            return context.UserImages
                .Include(x => x.User)
                .Where(x => x.UserId.Equals(userId))
                .OrderByDescending(x => x.DateUploaded)
                .ToList();
        }
    }
}

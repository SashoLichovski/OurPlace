using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;

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
        }
    }
}

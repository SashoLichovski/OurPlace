using LazZiya.ImageResize;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using OurPlace.Data;
using OurPlace.Services.Common;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Drawing;

namespace OurPlace.Services
{
    public class UserService : IUserService
    {
        private readonly UserManager<User> userManager;
        private readonly ApplicationDbContext context;

        public UserService(UserManager<User> userManager, ApplicationDbContext context)
        {
            this.userManager = userManager;
            this.context = context;
        }

        public Response UpdateFullName(string firstName, string lastName, string userId)
        {
            var response = new Response();
            var user = GetById(userId);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                userManager.UpdateAsync(user);
                context.SaveChanges();
            }
            else
            {
                response.Error = "Something went wrong. User was not found.";
            }
            return response;
        }

        public User GetById(string userId)
        {
            return userManager.FindByIdAsync(userId).Result;
        }

        public List<User> SearchUsers(string search)
        {
            var dbList = userManager.Users
                .Where(x => x.FirstName.Contains(search) || x.LastName.Contains(search) || x.Email.Contains(search))
                .ToList();
            return dbList;
        }

        public async Task UpdateCover(Image image, string userId)
        {
            var scaleImage = ImageResize.ScaleByWidth(image, 700);

            byte[] convertedImage = (byte[])(new ImageConverter()).ConvertTo(scaleImage, typeof(byte[]));

            var user = GetById(userId);
            user.CoverPhoto = convertedImage;
            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }
    }
}

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
        private readonly IImageService imageService;

        public UserService(UserManager<User> userManager, ApplicationDbContext context, IImageService imageService)
        {
            this.userManager = userManager;
            this.context = context;
            this.imageService = imageService;
        }

        public List<User> GetUserForChat(string chatName)
        {
            return userManager.Users.Where(x => chatName.Contains(x.Id)).ToList();
        }

        public async Task<Response> UpdateFullName(string firstName, string lastName, string userId)
        {
            var response = new Response();
            var user = GetById(userId);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                await userManager.UpdateAsync(user);
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

        public async Task UploadCover(Image image, string userId)
        {
            var uploadedImage = imageService.Upload(image);

            var user = GetById(userId);
            user.CoverPhoto = uploadedImage;

            imageService.Create(uploadedImage, userId);

            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }

        public async Task UpdateCoverProfile(byte[] imgByteArr, string userId, string photoType)
        {
            var user = GetById(userId);
            if (photoType == "cover")
            {
                user.CoverPhoto = imgByteArr;
            }
            else
            {
                user.ProfilePhoto = imgByteArr;
            }
            await userManager.UpdateAsync(user);
            await context.SaveChangesAsync();
        }
    }
}

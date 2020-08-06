using Microsoft.AspNetCore.Identity;
using OurPlace.Data;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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

        public void UpdateFullName(string firstName, string lastName, string userId)
        {
            var user = GetById(userId);
            if (user != null)
            {
                user.FirstName = firstName;
                user.LastName = lastName;
                userManager.UpdateAsync(user);
                context.SaveChanges();
            }
        }

        public User GetById(string userId)
        {
            return userManager.FindByIdAsync(userId).Result;
        }
    }
}

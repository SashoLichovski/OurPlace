using Microsoft.AspNetCore.Identity;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OurPlace.Services
{
    public class FriendService : IFriendService
    {
        private readonly IFriendRepository friendRepo;
        private readonly UserManager<User> userManager;
        private readonly INotificationRepository notRepo;

        public FriendService(IFriendRepository friendRepo, UserManager<User> userManager, INotificationRepository notRepo)
        {
            this.friendRepo = friendRepo;
            this.userManager = userManager;
            this.notRepo = notRepo;
        }

        public List<Friend> GetAll(string userId)
        {
            return friendRepo.GetAll(userId);
        } 

        public Response CreateFriends(string senderId, string userId)
        {
            var response = new Response();
            var friends = friendRepo.GetBySenderUserIds(senderId, userId);
            if (friends == null)
            {
                var notification = notRepo.GetByUserSenderId(senderId, userId);
                notRepo.Delete(notification);

                var userOne = userManager.FindByIdAsync(userId).Result;
                var userTwo = userManager.FindByIdAsync(senderId).Result;
                var friendOne = new Friend()
                {
                    DateCreated = DateTime.Now,
                    UserId = userId,
                    FriendId = senderId,
                };
                if (userTwo.FirstName != null)
                {

                    friendOne.FriendName = $"{userTwo.FirstName} {userTwo.LastName}";
                }
                else
                {
                    friendOne.FriendName = userTwo.Email;
                }

                friendRepo.Add(friendOne);

                var friendTwo = new Friend()
                {
                    DateCreated = DateTime.Now,
                    UserId = senderId,
                    FriendId = userId
                };
                if (userOne.FirstName != null)
                {
                    friendTwo.FriendName = $"{userOne.FirstName} {userOne.LastName}";
                }
                else
                {
                    friendTwo.FriendName = userOne.Email;
                }

                friendRepo.Add(friendTwo);

                response.SuccessMessage = $"You are now friends with {friendOne.FriendName}";
            }
            else
            {
                response.Error = "You are already friends";
            }
            return response;
        }
    }
}

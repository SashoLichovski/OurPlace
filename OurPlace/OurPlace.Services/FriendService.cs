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
        private readonly IChatService chatService;

        public FriendService(IFriendRepository friendRepo, UserManager<User> userManager, INotificationRepository notRepo, IChatService chatService)
        {
            this.friendRepo = friendRepo;
            this.userManager = userManager;
            this.notRepo = notRepo;
            this.chatService = chatService;
        }

        public List<Friend> GetAll(string userId)
        {
            return friendRepo.GetAll(userId);
        } 

        private Friend Create(User user, string senderId, string userId)
        {
            var friend = new Friend()
            {
                DateCreated = DateTime.Now,
                UserId = userId,
                FriendId = senderId
            };
            if (!string.IsNullOrEmpty(user.FirstName))
            {
                friend.FriendName = $"{user.FirstName} {user.LastName}";
            }
            else
            {
                friend.FriendName = $"{user.Email}";
            }

            return friend;
        }

        public Response CreateFriends(string senderId, string userId)
        {
            var response = new Response();

            var not = notRepo.GetByUserSenderId(senderId, userId);
            notRepo.Delete(not);

            var userOne = userManager.FindByIdAsync(userId).Result;
            var userTwo = userManager.FindByIdAsync(senderId).Result;

            var friendOne = Create(userTwo, senderId, userId);
            var friendTwo = Create(userOne, userId, senderId);

            friendRepo.Add(friendOne);
            friendRepo.Add(friendTwo);

            chatService.Create(senderId, userId);

            response.SuccessMessage = $"You are now friends with {friendOne.FriendName}";

            return response;
        }

        public List<Friend> GetUserAsFriend(string userId)
        {
            return friendRepo.GetUserAsFriend(userId);
        }

        public void Update(Friend friend)
        {
            friendRepo.Update(friend);
        }
    }
}

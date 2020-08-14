using Microsoft.AspNetCore.Identity;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;

namespace OurPlace.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notRepo;
        private readonly UserManager<User> userManager;
        private readonly IFriendRepository friendRepo;

        public NotificationService(INotificationRepository notRepo, UserManager<User> userManager, IFriendRepository friendRepo)
        {
            this.notRepo = notRepo;
            this.userManager = userManager;
            this.friendRepo = friendRepo;
        }

        public Response CreateFriendRequest(string senderId, string userId)
        {
            var response = new Response();
            var not = notRepo.GetByUserSenderId(senderId, userId);
            var friends = friendRepo.GetBySenderUserIds(senderId, userId);

            if (friends != null)
            {
                response.Error = "You are already friends";
            }
            else if (not != null)
            {
                response.Error = "You already have sent or received friend request from this user.";
            }
            else
            {
                var sender = userManager.FindByIdAsync(senderId).Result;
                var notification = new Notification()
                {
                    DateSent = DateTime.Now,
                    UserId = userId,
                    SenderId = senderId
                };
                if (!string.IsNullOrEmpty(sender.FirstName))
                {
                    notification.SentBy = $"{sender.FirstName} {sender.LastName}";
                }
                else
                {
                    notification.SentBy = sender.Email;
                }
                response.SuccessMessage = "Friend request successfully sent";
                notRepo.Add(notification);
            }
            
            return response;
        }

        public void DeclineFriendRequest(string senderId, string userId)
        {
            var not = notRepo.GetByUserSenderId(senderId, userId);
            notRepo.Delete(not);
        }

        public List<Notification> GetAllForUser(string userId)
        {
            return notRepo.GetAllForUser(userId);
        }
    }
}

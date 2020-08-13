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

        public NotificationService(INotificationRepository notRepo, UserManager<User> userManager)
        {
            this.notRepo = notRepo;
            this.userManager = userManager;
        }

        public Response CreateFriendRequest(string senderId, string userId)
        {
            var not = notRepo.GetByUserSenderId(senderId, userId);
            var response = new Response();
            if (not == null)
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
            else
            {
                response.Error = "You already have sent or received friend request from this user.";
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

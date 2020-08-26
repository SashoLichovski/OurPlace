using Microsoft.AspNetCore.Identity;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Common;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Services
{
    public class NotificationService : INotificationService
    {
        private readonly INotificationRepository notRepo;
        private readonly UserManager<User> userManager;
        private readonly IFriendRepository friendRepo;
        private readonly IPostService postService;
        private readonly ICommentService commentService;

        public NotificationService(INotificationRepository notRepo, UserManager<User> userManager, IFriendRepository friendRepo, IPostService postService, ICommentService commentService)
        {
            this.notRepo = notRepo;
            this.userManager = userManager;
            this.friendRepo = friendRepo;
            this.postService = postService;
            this.commentService = commentService;
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
                    SenderId = senderId,
                    SentBy = $"{sender.FirstName} {sender.LastName}",
                    Message = $"{sender.FirstName} {sender.LastName} wants to be you friend",
                    Type = NotificationType.FriendRequest
                };
                
                response.SuccessMessage = $"Friend request successfully sent to {sender.FirstName} {sender.LastName}";
                notRepo.Add(notification);
            }
            
            return response;
        }

        public void DeclineFriendRequest(string senderId, string userId)
        {
            var not = notRepo.GetByUserSenderId(senderId, userId);
            notRepo.Delete(not);
        }

        public void Delete(int id)
        {
            var not = notRepo.GetById(id);
            notRepo.Delete(not);
        }

        public List<Notification> GetAllForUser(string userId)
        {
            return notRepo.GetAllForUser(userId);
        }

        public async Task<NotificationDto> CommentLikeNotification(string userId, string friendId, int commentId, bool didLike)
        {
            var sender = await userManager.FindByIdAsync(userId);
            var newNot = new Notification()
            {
                UserId = friendId,
                SenderId = sender.Id,
                SentBy = $"{sender.FirstName} {sender.LastName}",
                DateSent = DateTime.Now,
                Type = NotificationType.Other,
            };
            var comment = commentService.GetById(commentId);
            var shortPostMessage = "";
            if (comment.Message.Count() < 10)
            {
                shortPostMessage = comment.Message.Substring(0, comment.Message.Count());
            }
            else
            {
                shortPostMessage = comment.Message.Substring(0, 10);
            }

            if (didLike)
            {
                newNot.Message = $"{newNot.SentBy} likes your comment  ``{shortPostMessage}...``";
            }
            else
            {
                newNot.Message = $"{newNot.SentBy} dislikes your comment  ``{shortPostMessage}...``";
            }
            notRepo.Add(newNot);

            return newNot.ToNotificationDto();
        }

        public NotificationDto LikeNotification(string userId, string friendId, int postId, bool didLike)
        {
            var sender = userManager.FindByIdAsync(userId).Result;
            var newNot = new Notification()
            {
                UserId = friendId,
                SenderId = sender.Id,
                SentBy = $"{sender.FirstName} {sender.LastName}",
                DateSent = DateTime.Now,
                Type = NotificationType.Other,
            };
            var post = postService.GetById(postId);
            var shortPostMessage = "";
            if (!string.IsNullOrEmpty(post.Message))
            {
                if (post.Message.Count() < 10)
                {
                    shortPostMessage = post.Message.Substring(0, post.Message.Count());
                }
                else
                {
                    shortPostMessage = post.Message.Substring(0, 10);
                }
            }

            if (didLike)
            {
                newNot.Message = $"{newNot.SentBy} likes your post  ``{shortPostMessage}...``";
            }
            else
            {
                newNot.Message = $"{newNot.SentBy} dislikes your post  ``{shortPostMessage}...``";
            }
            notRepo.Add(newNot);

            return newNot.ToNotificationDto();
        }

        public NotificationDto PostNotification(string userId, string friendId, int postId)
        {
            var sender = userManager.FindByIdAsync(userId).Result;
            var newNot = new Notification()
            {
                UserId = friendId,
                SenderId = sender.Id,
                SentBy = $"{sender.FirstName} {sender.LastName}",
                DateSent = DateTime.Now,
                Type = NotificationType.Other,
            };
            var post = postService.GetById(postId);
            var shortPostMessage = "";
            if (!string.IsNullOrEmpty(post.Message))
            {
                if (post.Message.Count() < 10)
                {
                    shortPostMessage = post.Message.Substring(0, post.Message.Count());
                }
                else
                {
                    shortPostMessage = post.Message.Substring(0, 10);
                }
            }
            newNot.Message = $"{newNot.SentBy} commented on your post  ``{shortPostMessage}...``";
            notRepo.Add(newNot);

            return newNot.ToNotificationDto();
        }
    }
}

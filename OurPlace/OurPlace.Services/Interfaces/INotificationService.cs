﻿using OurPlace.Data;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OurPlace.Services.Interfaces
{
    public interface INotificationService
    {
        Response CreateFriendRequest(string senderId, string userId);
        List<Notification> GetAllForUser(string userId);
        void DeclineFriendRequest(string senderId, string userId);
        NotificationDto LikeNotification(string userId, string friendId, int postId, bool didLike);
        void Delete(int id);
        NotificationDto PostNotification(string userId, string friendId, int postId);
        Task<NotificationDto> CommentLikeNotification(string userId, string friendId, int entityId, bool didLike);
        Task<NotificationDto> ImageLikeNotification(string userId, string friendId, int entityId, bool didLike);
    }
}

using OurPlace.Data;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;

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
    }
}

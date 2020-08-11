using OurPlace.Data;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface INotificationService
    {
        Response CreateFriendRequest(string senderId, string userId);
        List<Notification> GetAllForUser(string userId);
    }
}

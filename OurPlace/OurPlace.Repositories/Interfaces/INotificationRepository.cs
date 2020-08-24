using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface INotificationRepository
    {
        void Add(Notification notification);
        List<Notification> GetAllForUser(string userId);
        Notification GetByUserSenderId(string senderId, string userId);
        void Delete(Notification not);
        Notification GetById(int id);
    }
}

using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly ApplicationDbContext context;

        public NotificationRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Notification notification)
        {
            context.Notifications.Add(notification);
            context.SaveChanges();
        }

        public List<Notification> GetAllForUser(string userId)
        {
            return context.Notifications.Where(x => x.UserId.Equals(userId)).ToList();
        }

        public Notification GetByUserSenderId(string senderId, string userId)
        {
            return context.Notifications.FirstOrDefault(x => x.UserId.Equals(userId) && x.SenderId.Equals(senderId) ||
            x.UserId.Equals(senderId) && x.SenderId.Equals(userId));
        }
    }
}

using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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

        public void Delete(Notification not)
        {
            context.Notifications.Remove(not);
            context.SaveChanges();
        }

        public List<Notification> GetAllForUser(string userId)
        {
            return context.Notifications
                .Where(x => x.UserId.Equals(userId))
                .OrderByDescending(x => x.DateSent)
                .ToList();
        }

        public Notification GetById(int id)
        {
            return context.Notifications.FirstOrDefault(x => x.Id.Equals(id));
        }

        public Notification GetByUserSenderId(string senderId, string userId)
        {
            return context.Notifications.FirstOrDefault(x => x.UserId.Equals(userId) && x.SenderId.Equals(senderId) ||
            x.UserId.Equals(senderId) && x.SenderId.Equals(userId));
        }
    }
}

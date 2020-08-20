using OurPlace.Models.Notification;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Helpers.Notification
{
    public static class Convert
    {
        internal static NotificationOverviewModel ToNotificationOverviewModel(this Data.Notification x)
        {
            return new NotificationOverviewModel
            {
                Id = x.Id,
                SenderId = x.SenderId,
                SentBy = x.SentBy,
                UserId = x.UserId,
                User = x.User,
                Message = x.Message,
                DateSent = x.DateSent,
                Type = x.Type
            };
        }
    }
}

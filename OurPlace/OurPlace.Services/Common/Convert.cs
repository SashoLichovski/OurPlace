using OurPlace.Data;
using OurPlace.Services.DtoModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurPlace.Services.Common
{
    public static class Convert
    {
        internal static NotificationDto ToNotificationDto(this Notification x)
        {
            return new NotificationDto
            {
                Id = x.Id,
                Message = x.Message,
                Type = x.Type,
                DateSent = x.DateSent,
                User = x.User,
                UserId = x.UserId,
                SentBy = x.SentBy,
                SenderId = x.SenderId
            };
        }
    }
}

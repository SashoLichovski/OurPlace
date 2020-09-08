using OurPlace.Data;
using System;
using System.Collections.Generic;
using System.Text;

namespace OurPlace.Services.DtoModels
{
    public class NotificationDto
    {
        public int Id { get; set; }
        public string SentBy { get; set; }
        public string SenderId { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public NotificationType Type { get; set; }
        public string UserId { get; set; }
        public Data.User User { get; set; }
        public byte[] Image { get; set; }
    }
}

using System;

namespace OurPlace.Models.Notification
{
    public class NotificationOverviewModel
    {
        public int Id { get; set; }
        public string SentBy { get; set; }
        public string SenderId { get; set; }
        public DateTime DateSent { get; set; }
        public string UserId { get; set; }
        public Data.User User { get; set; }
    }
}

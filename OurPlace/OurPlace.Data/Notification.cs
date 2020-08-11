using System;
using System.ComponentModel.DataAnnotations;

namespace OurPlace.Data
{
    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string SentBy { get; set; }
        [Required]
        public string SenderId { get; set; }
        [Required]
        public DateTime DateSent { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
    }
}

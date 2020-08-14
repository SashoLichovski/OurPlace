using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OurPlace.Data
{
    public class Message
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public int ChatId { get; set; }
        public Chat Chat { get; set; }
    }
}

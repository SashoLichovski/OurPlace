using System;
using System.ComponentModel.DataAnnotations;

namespace OurPlace.Data
{
    public class Post
    {
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        public byte[] Image { get; set; }
        [Required]
        public DateTime DatePosted { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }
    }
}

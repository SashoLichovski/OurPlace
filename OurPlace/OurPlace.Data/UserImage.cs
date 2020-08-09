using System;
using System.ComponentModel.DataAnnotations;

namespace OurPlace.Data
{
    public class UserImage
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateUploaded { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

    }
}

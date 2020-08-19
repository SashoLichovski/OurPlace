using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OurPlace.Data
{
    public abstract class Like
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public DateTime DateLiked { get; set; }
    }
}

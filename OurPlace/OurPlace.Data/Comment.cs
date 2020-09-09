using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OurPlace.Data
{
    public abstract class Comment 
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Message { get; set; }
        [Required]
        public DateTime DateSent { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }

        public List<CommentLike> Likes { get; set; }
    }
}

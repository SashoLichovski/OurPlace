using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OurPlace.Data
{
    public class Friend
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public User User { get; set; }
        [Required]
        public string FriendId { get; set; }
        [Required]
        public string FriendName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
    }
}

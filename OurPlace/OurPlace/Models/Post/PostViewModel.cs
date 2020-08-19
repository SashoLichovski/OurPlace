using System;
using System.Collections.Generic;

namespace OurPlace.Models.Post
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public byte[] Image { get; set; }
        public DateTime DatePosted { get; set; }
        public string UserId { get; set; }
        public Data.User User { get; set; }
        public List<PostLikeViewModel> Likes { get; set; }
    }
}

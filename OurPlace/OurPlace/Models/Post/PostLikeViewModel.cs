using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.Post
{
    public class PostLikeViewModel
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public Data.User User { get; set; }
        public int PostId { get; set; }
    }
}

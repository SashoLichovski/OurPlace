using System;
using System.Collections.Generic;
using System.Text;

namespace OurPlace.Data
{
    public class PostLike : Like
    {
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}

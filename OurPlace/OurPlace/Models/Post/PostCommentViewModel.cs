using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.Post
{
    public class PostCommentViewModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public string SentBy { get; set; }
        public string UserId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.Image
{
    public class ImageCommentModel
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public string CommentBy { get; set; }
        public string UserId { get; set; }
        public DateTime DateCreated { get; set; }
    }
}

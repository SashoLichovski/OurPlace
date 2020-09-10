using System;
using System.Collections.Generic;
using System.Text;

namespace OurPlace.Services.DtoModels
{
    public class ImageCommentDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public string SentBy { get; set; }
        public string UserId { get; set; }
    }
}

using OurPlace.Data;
using System;

namespace OurPlace.Services.DtoModels
{
    public class PostCommentDto
    {
        public int Id { get; set; }
        public string Message { get; set; }
        public DateTime DateSent { get; set; }
        public string SentBy { get; set; }
    }
}

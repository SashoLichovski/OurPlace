using System;
using System.Collections.Generic;
using System.Text;

namespace OurPlace.Services.DtoModels
{
    public class MessageDto
    {
        public int Id { get; set; }
        public string Text { get; set; }
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public int ChatId { get; set; }
        public byte[] UserImage { get; set; }
        public string UserName { get; internal set; }
    }
}

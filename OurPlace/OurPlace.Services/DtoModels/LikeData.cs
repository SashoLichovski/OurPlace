using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using System.Text;

namespace OurPlace.Services.DtoModels
{
    public class LikeData
    {
        public int EntityId { get; set; }
        public string ConnectionName { get; set; }
        public string FriendId { get; set; }
        public string LikeType { get; set; }
    }
}

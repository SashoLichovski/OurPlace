using System.Collections.Generic;

namespace OurPlace.Models.User
{
    public abstract class BaseUserProfileModel
    {
        public List<string> FriendIds { get; set; }
        public string ProfileOwnerId { get; set; }
        public string VisitorId { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.User
{
    public class UserFriendModel : BaseUserProfileModel
    {
        public List<ListOfUserFriendModel> FriendList { get; set; }
        public UserLayoutPhotosModel Photos { get; set; }
    }
}

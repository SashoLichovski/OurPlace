using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.User
{
    public class UserInfoModel : BaseUserProfileModel
    {
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public UserLayoutPhotosModel Photos { get; set; }
    }
}

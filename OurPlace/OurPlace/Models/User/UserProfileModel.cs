using OurPlace.Models.Post;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.User
{
    public class UserProfileModel
    {
        public UserLayoutPhotosModel Photos { get; set; }
        public List<PostViewModel> Posts { get; set; }
    }
}

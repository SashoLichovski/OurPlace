using OurPlace.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.User
{
    public class UserPhotosModel
    {
        public UserLayoutPhotosModel LayoutPhotos { get; set; }
        public List<UserImageModel> UserPhotos { get; set; }
    }
}

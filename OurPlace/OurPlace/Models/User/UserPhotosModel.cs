using OurPlace.Models.Image;
using System.Collections.Generic;

namespace OurPlace.Models.User
{
    public class UserPhotosModel : BaseUserProfileModel
    {
        public UserLayoutPhotosModel LayoutPhotos { get; set; }
        public List<UserImageModel> UserPhotos { get; set; }
        public string VisitorUsername { get; set; }
    }
}

using OurPlace.Models.Image;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Helpers.Image
{
    public static class Convert
    {
        internal static UserImageModel ToUserImageModel(this Data.UserImage x)
        {
            return new UserImageModel
            {
                Id = x.Id,
                Image = x.Image,
                UserId = x.UserId,
                User = x.User,
                DateUploaded = x.DateUploaded
            };
        }
    }
}

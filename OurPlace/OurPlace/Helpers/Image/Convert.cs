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
            var model = new UserImageModel()
            {
                Id = x.Id,
                Image = x.Image,
                UserId = x.UserId,
                User = x.User,
                DateUploaded = x.DateUploaded,
                Likes = new List<ImageLikeModel>()
            };
            if (x.Likes != null)
            {
                model.Likes = x.Likes.Select(x => x.ToImageLikeModel()).ToList();
            }
            return model;
        }

        internal static ImageLikeModel ToImageLikeModel(this Data.ImageLike x)
        {
            return new ImageLikeModel
            {
                Id = x.Id,
                ImageId = x.ImageId,
                UserId = x.UserId,
                User = x.User
            };
        }
    }
}

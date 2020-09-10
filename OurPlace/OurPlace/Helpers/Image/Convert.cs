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
                Likes = new List<ImageLikeModel>(),
                Comments = new List<ImageCommentModel>()
            };
            model.Likes = x.Likes.Select(x => x.ToImageLikeModel()).ToList();
            model.Comments = x.Comments.Select(x => x.ToImageCommentModel()).ToList();
            return model;
        }

        private static ImageCommentModel ToImageCommentModel(this Data.ImageComment x)
        {
            return new ImageCommentModel
            {
                Id = x.Id,
                Message = x.Message,
                CommentBy = x.User.UserName,
                UserId = x.UserId,
                DateCreated = x.DateSent
            };
        }

        private static ImageLikeModel ToImageLikeModel(this Data.ImageLike x)
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

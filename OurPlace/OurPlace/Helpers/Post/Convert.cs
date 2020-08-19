using OurPlace.Models.Post;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Helpers.Post
{
    public static class Convert
    {
        internal static PostViewModel ToPostViewModel(this Data.Post x)
        {
            var model = new PostViewModel()
            {
                Id = x.Id,
                UserId = x.UserId,
                User = x.User,
                Message = x.Message,
                DatePosted = x.DatePosted,
                
            };

            if (x.Likes.Count == 0)
            {
                model.Likes = new List<PostLikeViewModel>();
            }
            else
            {
                model.Likes = x.Likes.Select(x => x.ToPostLikeViewModel()).ToList();
            }

            if (x.Image != null)
            {
                model.Image = x.Image;
            }
            return model;
        }

        internal static PostLikeViewModel ToPostLikeViewModel(this Data.PostLike x)
        {
            return new PostLikeViewModel
            {
                Id = x.Id,
                UserId = x.UserId,
                User = x.User,
                PostId = x.PostId
            };
        }
    }
}

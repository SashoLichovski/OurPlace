using OurPlace.Data;
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
            model.Comments = new List<PostCommentViewModel>();
            if (x.Comments != null)
            {
                model.Comments = x.Comments.Select(x => x.ToPostCommentViewModel()).ToList();
                for (int i = 0; i < x.Comments.Count; i++)
                {
                    if (x.Comments[i].Likes == null)
                    {
                        x.Comments[i].Likes = new List<CommentLike>();
                    }
                    model.Comments[i].CommentLikes = x.Comments[i].Likes.Select(x => x.ToCommentLikeViewModel()).ToList();
                }
            }

            model.Likes = new List<PostLikeViewModel>();
            if (x.Likes != null)
            {
                model.Likes = x.Likes.Select(x => x.ToPostLikeViewModel()).ToList();
            }

            

            if (x.Image != null)
            {
                model.Image = x.Image;
            }
            return model;
        }

        internal static PostCommentViewModel ToPostCommentViewModel(this Data.PostComment x)
        {
            return new PostCommentViewModel
            {
                Id = x.Id,
                Message = x.Message,
                DateSent = x.DateSent,
                SentBy = $"{x.User.UserName}",
                UserId = x.UserId
            };
        }

        internal static CommentLikeViewModel ToCommentLikeViewModel(this CommentLike x)
        {
            return new CommentLikeViewModel
            {
                Id = x.Id,
                CommentId = x.CommentId,
                UserId = x.UserId,
            };
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

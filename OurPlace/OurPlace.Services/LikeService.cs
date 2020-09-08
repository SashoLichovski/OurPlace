using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Interfaces;
using System;

namespace OurPlace.Services
{
    public class LikeService : ILikeService
    {
        private readonly ILikeRepository likeRepo;

        public LikeService(ILikeRepository likeRepo)
        {
            this.likeRepo = likeRepo;
        }

        public bool EditPostLike(int postId, string userId)
        {
            var didLike = false;
            var like = likeRepo.GetByUserPostId(userId, postId);
            if (like == null)
            {
                var postLike = new PostLike()
                {
                    UserId = userId,
                    PostId = postId,
                    DateLiked = DateTime.Now
                };
                likeRepo.AddPostLike(postLike);
                didLike = true;
            }
            else
            {
                likeRepo.RemovePostLike(like);
            }
            return didLike;
        }

        public bool EditCommentLike(int commentId, string userId)
        {
            var didLike = false;
            var like = likeRepo.GetByUserCommentId(userId, commentId);
            if (like == null)
            {
                var postLike = new CommentLike()
                {
                    UserId = userId,
                    CommentId = commentId,
                    DateLiked = DateTime.Now
                };
                likeRepo.AddCommentLike(postLike);
                didLike = true;
            }
            else
            {
                likeRepo.RemoveCommentLike(like);
            }
            return didLike;
        }

        public bool EditImageLike(int imageId, string userId)
        {
            var didLike = false;
            var like = likeRepo.GetByUserImageId(userId, imageId);
            if (like == null)
            {
                var imageLike = new ImageLike()
                {
                    UserId = userId,
                    ImageId = imageId,
                    DateLiked = DateTime.Now
                };
                likeRepo.AddImageLike(imageLike);
                didLike = true;
            }
            else
            {
                likeRepo.RemoveImageLike(like);
            }
            return didLike;
        }
    }
}

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
    }
}

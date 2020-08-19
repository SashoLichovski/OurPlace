using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Linq;

namespace OurPlace.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext context;

        public LikeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddPostLike(PostLike postLike)
        {
            context.PostLikes.Add(postLike);
            context.SaveChanges();
        }

        public void RemovePostLike(PostLike like)
        {
            context.PostLikes.Remove(like);
            context.SaveChanges();
        }

        public PostLike GetByUserPostId(string userId, int postId)
        {
            return context.PostLikes.FirstOrDefault(x => x.UserId.Equals(userId) && x.PostId.Equals(postId));
        }
    }
}

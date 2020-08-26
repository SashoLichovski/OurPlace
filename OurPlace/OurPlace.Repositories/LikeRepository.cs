using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Repositories
{
    public class LikeRepository : ILikeRepository
    {
        private readonly ApplicationDbContext context;

        public LikeRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public async Task AddPostLike(PostLike postLike)
        {
            context.PostLikes.Add(postLike);
            await context.SaveChangesAsync();
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

        public CommentLike GetByUserCommentId(string userId, int commentId)
        {
            return context.CommentLikes.FirstOrDefault(x => x.UserId.Equals(userId) && x.CommentId.Equals(commentId));
        }

        public void RemoveCommentLike(CommentLike like)
        {
            context.CommentLikes.Remove(like);
            context.SaveChanges();
        }

        public async Task AddCommentLike(CommentLike commentLike)
        {
            context.CommentLikes.Add(commentLike);
            await context.SaveChangesAsync();
        }
    }
}

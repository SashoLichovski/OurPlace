using OurPlace.Data;
using System.Threading.Tasks;

namespace OurPlace.Repositories.Interfaces
{
    public interface ILikeRepository
    {
        void AddPostLike(PostLike postLike);
        PostLike GetByUserPostId(string userId, int postId);
        CommentLike GetByUserCommentId(string userId, int commentId);
        void RemovePostLike(PostLike like);
        void RemoveCommentLike(CommentLike like);
        Task AddCommentLike(CommentLike commentLike);
    }
}

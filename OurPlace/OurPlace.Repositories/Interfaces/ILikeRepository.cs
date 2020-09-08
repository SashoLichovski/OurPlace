using OurPlace.Data;
using System.Threading.Tasks;

namespace OurPlace.Repositories.Interfaces
{
    public interface ILikeRepository
    {
        PostLike GetByUserPostId(string userId, int postId);
        Task AddPostLike(PostLike postLike);
        void RemovePostLike(PostLike like);
        CommentLike GetByUserCommentId(string userId, int commentId);
        Task AddCommentLike(CommentLike commentLike);
        void RemoveCommentLike(CommentLike like);
        ImageLike GetByUserImageId(string userId, int imageId);
        Task AddImageLike(ImageLike imageLike);
        void RemoveImageLike(ImageLike like);
    }
}

using OurPlace.Data;

namespace OurPlace.Repositories.Interfaces
{
    public interface ILikeRepository
    {
        void AddPostLike(PostLike postLike);
        PostLike GetByUserPostId(string userId, int postId);
        void RemovePostLike(PostLike like);
    }
}

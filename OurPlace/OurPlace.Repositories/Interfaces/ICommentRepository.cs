using OurPlace.Data;

namespace OurPlace.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void AddPostComment(PostComment postComment);
    }
}

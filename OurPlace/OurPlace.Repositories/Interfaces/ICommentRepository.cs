using OurPlace.Data;

namespace OurPlace.Repositories.Interfaces
{
    public interface ICommentRepository
    {
        void AddPostComment(PostComment postComment);
        PostComment GetById(int commentId);
        void Delete(PostComment comment);
        void AddImageComment(ImageComment imageComment);
    }
}

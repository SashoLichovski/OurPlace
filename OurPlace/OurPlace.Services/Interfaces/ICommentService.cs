using OurPlace.Data;
using OurPlace.Services.DtoModels;

namespace OurPlace.Services.Interfaces
{
    public interface ICommentService
    {
        PostCommentDto CreatePostComment(int postId, string userId, string message);
        void Delete(int commentId);
        PostComment GetById(int commentId);
        ImageCommentDto CreateImageComment(int imageId, string userId, string message);
    }
}

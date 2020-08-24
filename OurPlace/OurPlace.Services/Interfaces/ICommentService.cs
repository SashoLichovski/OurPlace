using OurPlace.Services.DtoModels;

namespace OurPlace.Services.Interfaces
{
    public interface ICommentService
    {
        PostCommentDto CreatePostComment(int postId, string userId, string message);
    }
}

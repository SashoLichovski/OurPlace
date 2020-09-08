namespace OurPlace.Services.Interfaces
{
    public interface ILikeService
    {
        bool EditPostLike(int postId, string userId);
        bool EditCommentLike(int commentId, string userId);
        bool EditImageLike(int entityId, string userId);
    }
}

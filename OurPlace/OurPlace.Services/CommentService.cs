using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Common;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System;

namespace OurPlace.Services
{
    public class CommentService : ICommentService
    {
        private readonly ICommentRepository commentRepo;
        private readonly IUserService userService;

        public CommentService(ICommentRepository commentRepo, IUserService userService)
        {
            this.commentRepo = commentRepo;
            this.userService = userService;
        }

        public PostCommentDto CreatePostComment(int postId, string userId, string message)
        {
            var sender = userService.GetById(userId);
            var postComment = new PostComment()
            {
                UserId = userId,
                PostId = postId,
                Message = message,
                DateSent = DateTime.Now
            };
            commentRepo.AddPostComment(postComment);

            var model = postComment.ToPostCommentDto();
            model.SentBy = $"{sender.FirstName} {sender.LastName}";

            return model;
        }

        public void Delete(int commentId)
        {
            var comment = commentRepo.GetById(commentId);
            if (comment != null)
            {
                commentRepo.Delete(comment);
            }
        }

        public PostComment GetById(int commentId)
        {
            return commentRepo.GetById(commentId);
        }
    }
}

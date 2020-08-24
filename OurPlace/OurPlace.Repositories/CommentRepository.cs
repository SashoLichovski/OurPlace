using OurPlace.Data;
using OurPlace.Repositories.Interfaces;

namespace OurPlace.Repositories
{
    public class CommentRepository : ICommentRepository
    {
        private readonly ApplicationDbContext context;

        public CommentRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void AddPostComment(PostComment postComment)
        {
            context.PostComments.Add(postComment);
            context.SaveChanges();
        }
    }
}

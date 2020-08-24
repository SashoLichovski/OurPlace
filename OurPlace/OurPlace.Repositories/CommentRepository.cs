using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Linq;

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

        public void Delete(PostComment comment)
        {
            context.PostComments.Remove(comment);
            context.SaveChanges();
        }

        public PostComment GetById(int commentId)
        {
            return context.PostComments.FirstOrDefault(x => x.Id.Equals(commentId));
        }
    }
}

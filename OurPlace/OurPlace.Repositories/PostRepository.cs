using Microsoft.EntityFrameworkCore;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Repositories
{
    public class PostRepository : IPostRepository
    {
        private readonly ApplicationDbContext context;

        public PostRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Post post)
        {
            context.Posts.Add(post);
            context.SaveChanges();
        }

        public List<Post> GetAll(string userId)
        {
            return context.Posts
                .Include(x => x.User)
                .Where(x => x.UserId.Equals(userId))
                .OrderByDescending(x => x.DatePosted)
                .ToList();
        }
    }
}

using Microsoft.EntityFrameworkCore;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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

        public void Delete(Post post)
        {
            context.Posts.Remove(post);
            context.SaveChanges();
        }

        public List<Post> GetAllForHomePage(List<string> userIds)
        {
            var posts = context.Posts
                .Include(x => x.Comments)
                    .ThenInclude(x => x.Likes)
                    //.ThenInclude(x => x.User)
                .Include(x => x.Likes)
                    //.ThenInclude(x => x.User)
                .Include(x => x.User)
                .Where(x => userIds.Contains(x.UserId))
                .OrderByDescending(x => x.DatePosted)
                .Take(20)
                .ToList();

            return posts;
        }

        public List<Post> GetAllForTimeline(string userId)
        {
            return context.Posts
                .Include(x => x.Comments)
                    .ThenInclude(x => x.User)
                .Include(x => x.Likes)
                    .ThenInclude(x => x.User)
                .Include(x => x.User)
                .Where(x => x.UserId.Equals(userId))
                .OrderByDescending(x => x.DatePosted)
                .ToList();
        }

        public Post GetById(int postId)
        {
            return context.Posts.FirstOrDefault(x => x.Id.Equals(postId));
        }

        public void Update(Post dbPost)
        {
            context.Posts.Update(dbPost);
            context.SaveChanges();
        }
    }
}

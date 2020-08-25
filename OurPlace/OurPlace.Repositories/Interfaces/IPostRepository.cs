using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        List<Post> GetAllForTimeline(string userId);
        List<Post> GetAllForHomePage(List<string> usersIds);
        Post GetById(int postId);
        void Delete(Post post);
        void Update(Post dbPost);
    }
}

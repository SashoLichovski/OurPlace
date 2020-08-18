using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IPostRepository
    {
        void Add(Post post);
        List<Post> GetAll(string userId);
    }
}

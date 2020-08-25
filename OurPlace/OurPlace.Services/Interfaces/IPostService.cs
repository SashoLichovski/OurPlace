using Microsoft.AspNetCore.Http;
using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IPostService
    {
        void Create(string userId, IFormFile image, string message);
        List<Post> GetAllForTimeline(string userId);
        List<Post> GetAllForHomePage(string userId);
        Post GetById(int postId);
        void Delete(int postId);
        void Update(int postId, string message);
    }
}

using Microsoft.AspNetCore.Http;
using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IPostService
    {
        void Create(string userId, IFormFile image, string message);
        List<Post> GetAll(string userId);
    }
}

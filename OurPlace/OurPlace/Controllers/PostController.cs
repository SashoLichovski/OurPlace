using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        public IActionResult Create(string userId, IFormFile image, string message)
        {
            postService.Create(userId, image, message);
            return RedirectToAction("Profile", "User",new { UserId = userId });
        }
    }
}

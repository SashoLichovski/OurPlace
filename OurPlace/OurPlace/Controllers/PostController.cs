using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    [Authorize]
    public class PostController : Controller
    {
        private readonly IPostService postService;

        public PostController(IPostService postService)
        {
            this.postService = postService;
        }

        [HttpPost]
        public IActionResult Create(string userId, IFormFile image, string message, string page)
        {
            postService.Create(userId, image, message);
            if (page == "HomePage")
            {
                return RedirectToAction("HomePage", "Home");
            }
            return RedirectToAction("Profile", "User", new { UserId = userId });
        }
    }
}

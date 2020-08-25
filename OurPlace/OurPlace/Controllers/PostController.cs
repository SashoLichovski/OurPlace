using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Models.Post;
using OurPlace.Services.DtoModels;
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
            if (string.IsNullOrEmpty(message) && image == null)
            {
                return RedirectToAction("ActionResponse", "Home", new Response { Error = "You can't make an empty post. Please upload a picture or write something" });
            }
            postService.Create(userId, image, message);
            if (page == "HomePage")
            {
                return RedirectToAction("HomePage", "Home");
            }
            return RedirectToAction("Profile", "User", new { UserId = userId });
        }

        [HttpPost("[controller]/[action]/{postId}")]
        public IActionResult DeletePost(int postId)
        {
            postService.Delete(postId);
            return Ok();
        }

        [HttpPost("[controller]/[action]")]
        public IActionResult EditPost([FromBody] UpdatePostViewModel model)
        {
            postService.Update(model.PostId, model.Message);
            return Ok();
        }
    }
}

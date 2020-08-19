using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Helpers.Post;
using OurPlace.Models.Home;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace OurPlace.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IPostService postService;

        public HomeController(IPostService postService)
        {
            this.postService = postService;
        }
        
        [Authorize]
        public IActionResult HomePage()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var modelList = postService.GetAllForHomePage(userId).Select(x => x.ToPostViewModel()).ToList();
            var model = new HomePageViewModel()
            {
                Posts = modelList
            };
            return View(model);
        }

        public IActionResult ActionResponse(Response response)
        {
            return View(response);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    public class LikeController : Controller
    {
        private readonly ILikeService likeService;

        public LikeController(ILikeService likeService)
        {
            this.likeService = likeService;
        }
           
        public IActionResult PostLike(int postId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            likeService.EditPostLike(postId, userId);
            return RedirectToAction("HomePage", "Home");
        }
    }
}

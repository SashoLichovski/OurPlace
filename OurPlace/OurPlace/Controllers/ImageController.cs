using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    public class ImageController : Controller
    {
        private readonly IUserService userService;

        public ImageController(IUserService userService)
        {
            this.userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadCover(IFormFile coverImage)
        {
            var memoryStream = new MemoryStream();
            coverImage.CopyTo(memoryStream);
            var image = Image.FromStream(memoryStream);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await userService.UpdateCover(image, userId);
            return RedirectToAction("Profile", "User", new { UserId = userId });
        }


    }
}

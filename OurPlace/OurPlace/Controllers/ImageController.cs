using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OurPlace.Controllers
{
    public class ImageController : Controller
    {
        private readonly IUserService userService;
        private readonly IImageService imageService;

        public ImageController(IUserService userService, IImageService imageService)
        {
            this.userService = userService;
            this.imageService = imageService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadCover(IFormFile coverImage)
        {
            var image = imageService.FormFileToImage(coverImage);

            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            await userService.UpdateCover(image, userId);
            return RedirectToAction("Profile", "User", new { UserId = userId });
        }

        [HttpPost]
        public  IActionResult UploadImage(IFormFile userImage)
        {
            var image = imageService.FormFileToImage(userImage);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            imageService.AddImage(image, userId);
            return RedirectToAction("UserPhotos", "User", new { UserId = userId });

        }
    }
}

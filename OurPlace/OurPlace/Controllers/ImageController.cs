using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OurPlace.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> UploadCover(IFormFile coverImage, int imageId, string photoType)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            if (!string.IsNullOrEmpty(photoType))
            {
                byte[] imgByteArr = imageService.GetByteArrById(imageId);
                await userService.UpdateCoverProfile(imgByteArr, userId, photoType);
                return RedirectToAction("UserPhotos", "User", new { UserId = userId });
            }
            else if (coverImage != null)
            {
                var image = imageService.FormFileToImage(coverImage);

                await userService.UploadCover(image, userId);
                return RedirectToAction("Profile", "User", new { UserId = userId });
            }
            else
            {
                return RedirectToAction("ActionResponse", "Home", imageService.UploadError());
            }
            
        }

        [HttpPost]
        public  IActionResult UploadImage(IFormFile userImage)
        {
            if (userImage != null)
            {
                var image = imageService.FormFileToImage(userImage);
                var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
                imageService.AddImage(image, userId);
                return RedirectToAction("UserPhotos", "User", new { UserId = userId });
            }
            else
            {
                return RedirectToAction("ActionResponse", "Home", imageService.UploadError());
            }

        }

        [HttpPost]
        public IActionResult Delete(int imageId)
        {
            imageService.Delete(imageId);
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            return RedirectToAction("UserPhotos", "User", new { UserId = userId });
        }
    }
}

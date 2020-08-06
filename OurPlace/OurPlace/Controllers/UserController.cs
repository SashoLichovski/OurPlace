using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Data;
using OurPlace.Models.User;
using System.Security.Claims;
using OurPlace.Helpers.User;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;

        public UserController(IUserService userService)
        {
            this.userService = userService;
        }

        public IActionResult Profile(string userId)
        {
            var model = new UserProfileModel();
            var user = userService.GetById(userId);
            model.Photos = user.ToUserLayoutPhotosModel();
            return View(model);
        }

        public IActionResult UserInfo(string userId)
        {
            var model = new UserInfoModel();
            var user = userService.GetById(userId);
            model = user.ToUserInfoModel();
            model.Photos = user.ToUserLayoutPhotosModel();
            return View(model);
        }

        public IActionResult EditFullName(string userId)
        {
            var model = new EditFullNameModel()
            {
                UserId = userId
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditFullName(EditFullNameModel model)
        {
            if (ModelState.IsValid)
            {
                userService.UpdateFullName(model.FirstName, model.LastName, model.UserId);
                return RedirectToAction("UserInfo", new { model.UserId });
            }
            return View(model);
        }
    }
}

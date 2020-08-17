using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using OurPlace.Helpers.Image;
using OurPlace.Helpers.User;
using OurPlace.Models.User;
using OurPlace.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IImageService imageService;

        public UserController(IUserService userService, IImageService imageService)
        {
            this.userService = userService;
            this.imageService = imageService;
        }

        public IActionResult Profile(string userId)
        {
            var model = new UserProfileModel()
            {
                Photos = userService.GetById(userId).ToUserLayoutPhotosModel()
            };
            return View(model);
        }
        public IActionResult UserPhotos(string userId)
        {
            var model = new UserPhotosModel()
            {
                LayoutPhotos = userService.GetById(userId).ToUserLayoutPhotosModel(),
                UserPhotos = imageService.GetUserPhotos(userId).Select(x => x.ToUserImageModel()).ToList()
            };
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
                UserId = userId,
                FirstName = userService.GetById(userId).FirstName,
                LastName = userService.GetById(userId).LastName
            };
            return View(model);
        }
        [HttpPost]
        public IActionResult EditFullName(EditFullNameModel model)
        {
            if (ModelState.IsValid)
            {
                var response = userService.UpdateFullName(model.FirstName, model.LastName, model.UserId);
                if (string.IsNullOrEmpty(response.Result.Error))
                {
                    return RedirectToAction("UserInfo", new { model.UserId });
                }
                return RedirectToAction("ActionResponse", "Home", response);
            }
            return View(model);
        }

        [HttpPost]
        public IActionResult Search(string search)
        {
            var dbList = userService.SearchUsers(search);
            var modelList = dbList.Select(x => x.ToSearchUserModel()).ToList();
            var model = new SearchResult { ModelList = modelList };
            return View("SearchResult", model);
        }

        //public IActionResult SearchResult(SearchResult model)
        //{
        //    return View(model);
        //}

    }
}

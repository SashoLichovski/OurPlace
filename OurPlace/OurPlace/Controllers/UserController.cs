using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Helpers.User;
using OurPlace.Models.User;
using OurPlace.Services.Interfaces;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Drawing;
using System;

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
                if (string.IsNullOrEmpty(response.Error))
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
            return View(modelList);
        }

        

    }
}

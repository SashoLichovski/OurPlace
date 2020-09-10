﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Helpers.Image;
using OurPlace.Helpers.Post;
using OurPlace.Helpers.User;
using OurPlace.Models.User;
using OurPlace.Services.Interfaces;
using System.Diagnostics;
using System.Linq;
using System.Security.Claims;

namespace OurPlace.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        private readonly IUserService userService;
        private readonly IImageService imageService;
        private readonly IPostService postService;
        private readonly IFriendService friendService;

        public UserController(IUserService userService, IImageService imageService, IPostService postService, IFriendService friendService)
        {
            this.userService = userService;
            this.imageService = imageService;
            this.postService = postService;
            this.friendService = friendService;
        }

        public IActionResult Profile(string userId)
        {
            var model = new UserProfileModel()
            {
                Photos = userService.GetById(userId).ToUserLayoutPhotosModel(),
                Posts = postService.GetAllForTimeline(userId).Select(x => x.ToPostViewModel()).ToList(),
                FriendIds = friendService.GetFriendIds(userId),
                VisitorId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                ProfileOwnerId = userId
            };
            return View(model);
        }
        public IActionResult UserPhotos(string userId)
        {
            var model = new UserPhotosModel()
            {
                LayoutPhotos = userService.GetById(userId).ToUserLayoutPhotosModel(),
                UserPhotos = imageService.GetUserPhotos(userId).Select(x => x.ToUserImageModel()).ToList(),
                FriendIds = friendService.GetFriendIds(userId),
                VisitorId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                ProfileOwnerId = userId
            };
            model.VisitorUsername = userService.GetById(model.VisitorId).UserName;

            return View(model);
        }

        public IActionResult UserInfo(string userId)
        {
            var model = new UserInfoModel();
            var user = userService.GetById(userId);
            model = user.ToUserInfoModel();
            model.Photos = user.ToUserLayoutPhotosModel();
            model.VisitorId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            model.FriendIds = friendService.GetFriendIds(userId);
            return View(model);
        }

        public IActionResult UserFriends(string userId)
        {
            var model = new UserFriendModel()
            {
                FriendList = userService.GetUserFriends(userId).Select(x => x.ToUserFriendModel()).ToList(),
                VisitorId = User.FindFirst(ClaimTypes.NameIdentifier).Value,
                FriendIds = friendService.GetFriendIds(userId),
                ProfileOwnerId = userId,
                Photos = userService.GetById(userId).ToUserLayoutPhotosModel()
            };
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


    }
}

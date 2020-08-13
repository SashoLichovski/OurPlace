using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    public class FriendController : Controller
    {
        private readonly IFriendService friendService;

        public FriendController(IFriendService friendService)
        {
            this.friendService = friendService;
        }

        public IActionResult CreateFriends(string senderId, string userId)
        {
            Response response = friendService.CreateFriends(senderId, userId);
            return RedirectToAction("ActionResponse", "Home", response);
        }
    }
}

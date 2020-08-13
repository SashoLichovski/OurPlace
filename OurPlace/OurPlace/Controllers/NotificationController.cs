using Microsoft.AspNetCore.Mvc;
using OurPlace.Helpers.Notification;
using OurPlace.Services.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace OurPlace.Controllers
{
    public class NotificationController : Controller
    {
        private readonly INotificationService notService;

        public NotificationController(INotificationService notService)
        {
            this.notService = notService;
        }
        public IActionResult Overview(string userId)
        {
            var dbList = notService.GetAllForUser(userId);
            var modelList = dbList.Select(x => x.ToNotificationOverviewModel()).ToList();
            return View(modelList);
        }

        public IActionResult FriendRequest(string userId)
        {
            var senderId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var response = notService.CreateFriendRequest(senderId, userId);
            
            return RedirectToAction("ActionResponse", "Home", response);
        }

        public IActionResult DeclineFriendRequest(string senderId, string userId)
        {
            notService.DeclineFriendRequest(senderId, userId);
            return RedirectToAction("Overview", new { UserId = userId });
        }
    }
}

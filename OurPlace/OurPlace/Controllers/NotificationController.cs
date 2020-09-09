using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Helpers.Notification;
using OurPlace.Services.Interfaces;
using System.Linq;
using System.Security.Claims;

namespace OurPlace.Controllers
{
    [Authorize]
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

        [HttpPost("[controller]/[action]/{id}")]
        public IActionResult Delete(int id)
        {
            notService.Delete(id);
            return Ok();
        }

        public IActionResult DeleteAll(string userId)
        {
            notService.DeleteAll(userId);
            return RedirectToAction(nameof(Overview), new { UserId = userId });
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OurPlace.Data;
using OurPlace.Hubs;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OurPlace.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class LikeController : Controller
    {
        private readonly IHubContext<ChatHub> chat;
        private readonly ILikeService likeService;
        private readonly INotificationService notService;

        public LikeController(IHubContext<ChatHub> chat, ILikeService likeService, INotificationService notService)
        {
            this.chat = chat;
            this.likeService = likeService;
            this.notService = notService;
        }

        [HttpPost("[action]/{entityId}/{connectionName}/{friendId}/{likeType}")]
        public async Task<IActionResult> EntityLike(int entityId, string connectionName, string friendId, string likeType)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            

            var notification = new NotificationDto();
            if (likeType == "post")
            {
                var didLike = likeService.EditPostLike(entityId, userId);
                notification = notService.LikeNotification(userId, friendId, entityId, didLike);
            }
            else if (likeType == "comment")
            {
                var didLike = likeService.EditCommentLike(entityId, userId);
                notification = notService.CommentLikeNotification(userId, friendId, entityId, didLike);
            }

            await chat.Clients.Group(connectionName).SendAsync("ReceiveLike", new
            {
                FriendId = friendId,
                UserId = userId,
                Notification = notification
            });

            if (userId == friendId)
            {
                notService.Delete(notification.Id);
            }

            return Ok();
        }
    }
}

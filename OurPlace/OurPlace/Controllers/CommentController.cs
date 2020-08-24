using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OurPlace.Data;
using OurPlace.Hubs;
using OurPlace.Services.Interfaces;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OurPlace.Controllers
{
    [Authorize]
    [Route("[controller]")]
    public class CommentController : Controller
    {
        private readonly IHubContext<ChatHub> chat;
        private readonly ICommentService commentService;
        private readonly INotificationService notificationService;

        public CommentController(IHubContext<ChatHub> chat, ICommentService commentService, INotificationService notificationService)
        {
            this.chat = chat;
            this.commentService = commentService;
            this.notificationService = notificationService;
        }

        [HttpPost("[action]/{postId}/{connectionName}/{friendId}/{message}")]
        public async Task<IActionResult> PostComment(int postId, string connectionName, string friendId, string message)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

            var model = commentService.CreatePostComment(postId, userId, message);

            var notification = notificationService.PostNotification(userId, friendId, postId);

            await chat.Clients.Group(connectionName).SendAsync("ReceivePostComment", new
            {
                SentBy = model.SentBy,
                Message = model.Message,
                DateSent = model.DateSent.ToString("MMMM dd yyyy HH:mm"),
                PostId = postId,
                Notification = notification,
                FriendId = friendId,
                UserId = userId
            });

            return Ok();
        }

        //[HttpPost("[action]/{id}")]
        //public IActionResult Delete(int id)
        //{

        //}
    }
}

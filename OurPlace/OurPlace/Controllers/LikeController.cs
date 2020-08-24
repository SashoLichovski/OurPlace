﻿using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("[action]/{postId}/{connectionName}/{friendId}")]
        public async Task<IActionResult> PostLike(int postId, string connectionName, string friendId)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var didLike = likeService.EditPostLike(postId, userId);

            var notification = notService.LikeNotification(userId, friendId, postId, didLike);

            await chat.Clients.Group(connectionName).SendAsync("ReceiveLike", new
            {
                FriendId = friendId,
                UserId = userId,
                PostId = postId,
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

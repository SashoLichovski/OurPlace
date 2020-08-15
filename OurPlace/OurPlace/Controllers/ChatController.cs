using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.SignalR;
using OurPlace.Data;
using OurPlace.Hubs;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    [Route("[controller]")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> chat;
        private readonly IMessageService messageService;
        private readonly ApplicationDbContext context;

        public ChatController(IHubContext<ChatHub> chat, IMessageService messageService, ApplicationDbContext context)
        {
            this.chat = chat;
            this.messageService = messageService;
            this.context = context;
        }

        [HttpPost("[action]/{connectionId}/{chatroomName}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string chatroomName)
        {
            await chat.Groups.AddToGroupAsync(connectionId, chatroomName);
            var currentPage = HttpContext.Request.GetDisplayUrl();
            return Redirect(currentPage);
        }

        [HttpPost("[action]/{connectionId}/{chatroomName}")]
        public async Task<IActionResult> LeaveRoom(string connectionId, string chatroomName)
        {
            await chat.Groups.RemoveFromGroupAsync(connectionId, chatroomName);
            return Ok();
        }

        [HttpPost("[action]")]
        public async Task<IActionResult> SendMessage(string text, string chatroomName)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var msg = await messageService.Create(userId, chatroomName, text);
            await chat.Clients.Group(chatroomName).SendAsync("ReceiveMessage", new
            {
                Text = msg.Text,
                CreatedBy = msg.UserName,
                UserImage = Convert.ToBase64String(msg.UserImage),
                DatePosted = msg.DateCreated.ToString("dd/MM/yyyy hh:mm"),
                UserId = msg.UserId
            });
            return Ok();
        }
    }
}

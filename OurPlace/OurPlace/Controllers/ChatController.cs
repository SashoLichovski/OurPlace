using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;
using OurPlace.Hubs;
using OurPlace.Services.Interfaces;
using System;
using System.Security.Claims;
using System.Threading.Tasks;

namespace OurPlace.Controllers
{
    [Route("[controller]")]
    public class ChatController : Controller
    {
        private readonly IHubContext<ChatHub> chat;
        private readonly IMessageService messageService;

        public ChatController(IHubContext<ChatHub> chat, IMessageService messageService)
        {
            this.chat = chat;
            this.messageService = messageService;
        }

        [HttpPost("[action]/{connectionId}/{chatroomName}")]
        public async Task<IActionResult> JoinRoom(string connectionId, string chatroomName)
        {
            await chat.Groups.AddToGroupAsync(connectionId, chatroomName);
            //This is test commit
            return Ok();
        }

        //[HttpPost("[action]/{connectionId}/{chatroomName}")]
        //public async Task<IActionResult> LeaveRoom(string connectionId, string chatroomName)
        //{
        //    await chat.Groups.RemoveFromGroupAsync(connectionId, chatroomName);
        //    return Ok();
        //}

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

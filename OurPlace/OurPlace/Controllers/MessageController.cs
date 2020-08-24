using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OurPlace.Services.Interfaces;

namespace OurPlace.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly IMessageService messageService;

        public MessageController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        public IActionResult Create(string userId, string chatName, string message)
        {
            messageService.Create(userId, chatName, message);
            var prevPage = Request.Headers["Referer"].ToString();
            return Redirect(prevPage);
        }
    }
}

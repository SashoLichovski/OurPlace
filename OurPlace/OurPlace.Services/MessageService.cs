using Microsoft.AspNetCore.Identity;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.DtoModels;
using OurPlace.Services.Interfaces;
using System;
using System.Threading.Tasks;

namespace OurPlace.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepo;
        private readonly IChatService chatService;
        private readonly UserManager<User> userManager;

        public MessageService(IMessageRepository messageRepo, IChatService chatService, UserManager<User> userManager)
        {
            this.messageRepo = messageRepo;
            this.chatService = chatService;
            this.userManager = userManager;
        }

        public async Task<MessageDto> Create(string userId, string chatName, string message)
        {
            var chatId = chatService.GetByName(chatName).Id;
            var user = userManager.FindByIdAsync(userId).Result;
            var msg = new Message()
            {
                UserId = userId,
                Text = message,
                ChatId = chatId,
                DateCreated = DateTime.Now
            };
            messageRepo.Add(msg);
            return new MessageDto
            {
                ChatId = msg.ChatId,
                Text = msg.Text,
                DateCreated = msg.DateCreated,
                UserId = userId,
                UserImage = user.ProfilePhoto,
                UserName = $"{user.FirstName} {user.LastName}"
            };
        }
    }
}

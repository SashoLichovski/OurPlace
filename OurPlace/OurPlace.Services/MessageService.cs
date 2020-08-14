using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Interfaces;
using System;

namespace OurPlace.Services
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository messageRepo;
        private readonly IChatService chatService;

        public MessageService(IMessageRepository messageRepo, IChatService chatService)
        {
            this.messageRepo = messageRepo;
            this.chatService = chatService;
        }

        public void Create(string userId, string chatName, string message)
        {
            var chatId = chatService.GetByName(chatName).Id;
            var msg = new Message()
            {
                UserId = userId,
                Text = message,
                ChatId = chatId,
                DateCreated = DateTime.Now
            };
            messageRepo.Add(msg);
        }
    }
}

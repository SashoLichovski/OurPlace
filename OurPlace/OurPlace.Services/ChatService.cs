using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using OurPlace.Services.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Services
{
    public class ChatService : IChatService
    {
        private readonly IChatRepository chatRepo;
        private readonly IFriendRepository friendRepo;

        public ChatService(IChatRepository chatRepo, IFriendRepository friendRepo)
        {
            this.chatRepo = chatRepo;
            this.friendRepo = friendRepo;
        }

        public void Create(string senderId, string userId)
        {
            var chat = new Chat()
            {
                ChatName = senderId + userId
            };

            chatRepo.Add(chat);
        }

        public List<Chat> GetAll(string userId)
        {
            var friendIds = friendRepo.GetAll(userId).Select(x => x.FriendId).ToList();
            return chatRepo.GetAll(userId, friendIds);
        }

        public Chat GetByName(string chatName)
        {
            return chatRepo.GetByName(chatName);
        }
    }
}

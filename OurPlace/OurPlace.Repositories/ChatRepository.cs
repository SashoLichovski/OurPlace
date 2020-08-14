using Microsoft.EntityFrameworkCore;
using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Repositories
{
    public class ChatRepository : IChatRepository
    {
        private readonly ApplicationDbContext context;

        public ChatRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Chat chat)
        {
            context.Chats.Add(chat);
            context.SaveChanges();
        }

        public List<Chat> GetAll(string userId, List<string> friendIds)
        {
            var dbChats = new List<Chat>();
            foreach (var friendId in friendIds)
            {
                var chat = context.Chats
                    .Include(x => x.Messages)
                    .ThenInclude(x => x.User)
                    .FirstOrDefault(x => x.ChatName.Equals(userId + friendId) || 
                    x.ChatName.Equals(friendId + userId));
                if (chat != null)
                {
                    dbChats.Add(chat);
                }
            }
            return dbChats;
        }

        public Chat GetByName(string chatName)
        {
            return context.Chats.FirstOrDefault(x => x.ChatName.Equals(chatName));
        }
    }
}

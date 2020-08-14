using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IChatRepository
    {
        void Add(Chat chat);
        List<Chat> GetAll(string userId, List<string> friendIds);
        Chat GetByName(string chatName);
    }
}

using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IChatService
    {
        void Create(string senderId, string userId);
        List<Chat> GetAll(string userId);
        Chat GetByName(string chatName);
    }
}

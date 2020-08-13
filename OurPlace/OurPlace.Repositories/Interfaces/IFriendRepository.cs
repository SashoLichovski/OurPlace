using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        Friend GetBySenderUserIds(string senderId, string userId);
        void Add(Friend friend);
        List<Friend> GetAll(string userId);
    }
}

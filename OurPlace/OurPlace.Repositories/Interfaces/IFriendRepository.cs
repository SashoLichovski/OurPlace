using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        Friend GetBySenderUserIds(string senderId, string userId);
        void Add(Friend friend);
        List<Friend> GetAll(string userId);
        List<Friend> GetUserAsFriend(string userId);
        void Update(Friend friend);
    }
}

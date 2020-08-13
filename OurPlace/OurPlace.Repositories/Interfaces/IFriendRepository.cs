using OurPlace.Data;

namespace OurPlace.Repositories.Interfaces
{
    public interface IFriendRepository
    {
        Friend GetBySenderUserIds(string senderId, string userId);
        void Add(Friend friend);
    }
}

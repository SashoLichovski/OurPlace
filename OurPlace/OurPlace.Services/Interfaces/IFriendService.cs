using OurPlace.Data;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IFriendService
    {
        Response CreateFriends(string senderId, string userId);
        List<Friend> GetAll(string userId);
        List<Friend> GetUserAsFriend(string userId);
        void Update(Friend friend);
        List<string> GetFriendIds(string userId);
    }
}

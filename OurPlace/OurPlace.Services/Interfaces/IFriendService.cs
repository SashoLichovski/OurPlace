using OurPlace.Services.DtoModels;

namespace OurPlace.Services.Interfaces
{
    public interface IFriendService
    {
        Response CreateFriends(string senderId, string userId);
    }
}

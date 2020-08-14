namespace OurPlace.Services.Interfaces
{
    public interface IMessageService
    {
        void Create(string userId, string chatName, string message);
    }
}

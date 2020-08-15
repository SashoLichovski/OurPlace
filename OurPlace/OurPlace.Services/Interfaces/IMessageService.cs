using OurPlace.Services.DtoModels;
using System.Threading.Tasks;

namespace OurPlace.Services.Interfaces
{
    public interface IMessageService
    {
        Task<MessageDto> Create(string userId, string chatName, string message);
    }
}

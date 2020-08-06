using OurPlace.Data;
using System.Threading.Tasks;

namespace OurPlace.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(string userId);
        void UpdateFullName(string firstName, string lastName, string userId);
    }
}

using OurPlace.Data;
using System.Threading.Tasks;
using System;
using OurPlace.Services.DtoModels;

namespace OurPlace.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(string userId);
        Response UpdateFullName(string firstName, string lastName, string userId);
    }
}

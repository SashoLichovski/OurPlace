using OurPlace.Data;
using System.Threading.Tasks;
using System;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(string userId);
        Response UpdateFullName(string firstName, string lastName, string userId);
        List<User> SearchUsers(string search);
    }
}

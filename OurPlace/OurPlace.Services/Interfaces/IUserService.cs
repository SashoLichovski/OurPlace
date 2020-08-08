using OurPlace.Data;
using System.Threading.Tasks;
using System;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace OurPlace.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(string userId);
        Response UpdateFullName(string firstName, string lastName, string userId);
        List<User> SearchUsers(string search);
        Task UpdateCover(List<IFormFile> image, string userId);
    }
}

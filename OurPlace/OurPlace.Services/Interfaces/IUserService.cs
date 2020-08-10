using OurPlace.Data;
using System.Threading.Tasks;
using System;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using System.Drawing;

namespace OurPlace.Services.Interfaces
{
    public interface IUserService
    {
        User GetById(string userId);
        Response UpdateFullName(string firstName, string lastName, string userId);
        List<User> SearchUsers(string search);
        Task UploadCover(Image image, string userId);
        Task UpdateCoverProfile(byte[] imgByteArr, string userId, string photoType);
    }
}

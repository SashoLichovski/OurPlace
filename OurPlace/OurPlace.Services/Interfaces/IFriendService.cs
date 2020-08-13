﻿using OurPlace.Data;
using OurPlace.Services.DtoModels;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IFriendService
    {
        Response CreateFriends(string senderId, string userId);
        List<Friend> GetAll(string userId);
    }
}

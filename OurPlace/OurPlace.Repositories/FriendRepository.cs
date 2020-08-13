﻿using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Linq;

namespace OurPlace.Repositories
{
    public class FriendRepository : IFriendRepository
    {
        private readonly ApplicationDbContext context;

        public FriendRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Friend friend)
        {
            context.Friends.Add(friend);
            context.SaveChanges();
        }

        public Friend GetBySenderUserIds(string senderId, string userId)
        {
            return context.Friends.FirstOrDefault(x => x.FriendId.Equals(userId) && x.UserId.Equals(senderId) ||
            x.FriendId.Equals(senderId) && x.UserId.Equals(userId));
        }
    }
}

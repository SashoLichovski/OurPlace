using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Collections.Generic;
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

        public List<Friend> GetAll(string userId)
        {
            return context.Friends.Where(x => x.UserId.Equals(userId)).ToList();
        }

        public Friend GetBySenderUserIds(string senderId, string userId)
        {
            return context.Friends.FirstOrDefault(x => x.FriendId.Equals(userId) && x.UserId.Equals(senderId) ||
            x.FriendId.Equals(senderId) && x.UserId.Equals(userId));
        }

        public List<Friend> GetUserAsFriend(string userId)
        {
            return context.Friends.Where(x => x.FriendId.Equals(userId)).ToList();
        }

        public void Update(Friend friend)
        {
            context.Friends.Update(friend);
            context.SaveChanges();
        }
    }
}

using OurPlace.Data;
using OurPlace.Repositories.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace OurPlace.Repositories
{
    public class GroupRepository : IGroupRepository
    {
        private readonly ApplicationDbContext context;

        public GroupRepository(ApplicationDbContext context)
        {
            this.context = context;
        }

        public void Add(Group newGroup)
        {
            context.Groups.Add(newGroup);
            context.SaveChanges();
        }

        public void Add(GroupUser groupUser)
        {
            context.GroupsUsers.Add(groupUser);
            context.SaveChanges();
        }

        public Group GetMostRecentByName(string groupName)
        {
            return context.Groups.OrderByDescending(x => x.DateCreated).FirstOrDefault(x => x.Name.Equals(groupName));
        }

        public Group GetById(int groupId)
        {
            return context.Groups.FirstOrDefault(x => x.Id.Equals(groupId));
        }

        public List<Group> GetGroups(string userId)
        {
            var groupIds = context.GroupsUsers.Where(x => x.UserId.Equals(userId))
                .Select(x => x.GroupId)
                .ToList();

            return context.Groups.Where(x => groupIds.Contains(x.Id)).ToList();
        }
    }
}

using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Repositories.Interfaces
{
    public interface IGroupRepository
    {
        List<Group> GetGroups(string userId);
        void Add(Group newGroup);
        void Add(GroupUser relation);
        Group GetById(int groupId);
        Group GetMostRecentByName(string groupName);
    }
}

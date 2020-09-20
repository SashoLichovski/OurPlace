using OurPlace.Data;
using System.Collections.Generic;

namespace OurPlace.Services.Interfaces
{
    public interface IGroupService
    {
        List<Group> GetGroups(string userId);
        void Create(string userId, string groupName);
    }
}

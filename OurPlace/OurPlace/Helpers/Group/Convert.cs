using OurPlace.Data;
using OurPlace.Models.Group;

namespace OurPlace.Helpers.Group
{
    public static class Convert
    {
        internal static GroupViewModel ToGroupViewModel(this Data.Group x)
        {
            return new GroupViewModel
            {
                Id = x.Id,
                Name = x.Name,
                GroupAdminId = x.GroupAdminId,
                GroupAdminName = x.GroupAdminName,
                DateCreated = x.DateCreated,
                MembersCount = x.MembersCount
            };
        }
    }
}

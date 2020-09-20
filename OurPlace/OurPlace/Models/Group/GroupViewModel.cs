using System;

namespace OurPlace.Models.Group
{
    public class GroupViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string GroupAdminId { get; set; }
        public string GroupAdminName { get; set; }
        public DateTime DateCreated { get; set; }
        public int MembersCount { get; set; }
    }
}

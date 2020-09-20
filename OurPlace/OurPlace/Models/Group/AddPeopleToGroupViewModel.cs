using System.Collections.Generic;

namespace OurPlace.Models.Group
{
    public class AddPeopleToGroupViewModel
    {
        public List<Data.User> Friends { get; set; }
        public int GroupId { get; internal set; }
    }
}

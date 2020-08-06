using Microsoft.AspNetCore.Identity;

namespace OurPlace.Data
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] CoverPhoto { get; set; }
        public byte[] ProfilePhoto { get; set; }
    }
}

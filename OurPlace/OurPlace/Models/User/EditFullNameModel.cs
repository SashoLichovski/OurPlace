using System.ComponentModel.DataAnnotations;

namespace OurPlace.Models.User
{
    public class EditFullNameModel
    {
        [Required]
        public string UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }

    }
}

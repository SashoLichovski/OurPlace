using System.ComponentModel.DataAnnotations;

namespace OurPlace.Data
{
    public class GroupUser
    {
        public int Id { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        [Required]
        public string UserId { get; set; }
        public User User { get; set; }

    }
}

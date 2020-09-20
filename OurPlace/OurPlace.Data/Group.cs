using System;
using System.ComponentModel.DataAnnotations;

namespace OurPlace.Data
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string GroupAdminId { get; set; }
        [Required]
        public string GroupAdminName { get; set; }
        [Required]
        public DateTime DateCreated { get; set; }
        public int MembersCount { get; set; }

    }
}

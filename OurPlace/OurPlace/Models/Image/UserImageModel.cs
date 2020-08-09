using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.Image
{
    public class UserImageModel
    {
        public int Id { get; set; }
        public byte[] Image { get; set; }
        public DateTime DateUploaded { get; set; }
        public string UserId { get; set; }
        public Data.User User { get; set; }
    }
}

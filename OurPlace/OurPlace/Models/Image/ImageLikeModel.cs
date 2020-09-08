using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.Image
{
    public class ImageLikeModel
    {
        public int Id { get; set; }
        public int ImageId { get; set; }
        public string UserId { get; set; }
        public Data.User User { get; set; }
    }
}

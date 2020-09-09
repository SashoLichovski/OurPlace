using System;
using System.Collections.Generic;
using System.Text;

namespace OurPlace.Data
{
    public class ImageComment : Comment
    {
        public int ImageId { get; set; }
        public UserImage Image { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OurPlace.Models.User
{
    public class UserLayoutPhotosModel
    {
        public string UserId { get; set; }
        public byte[] CoverPhoto { get; set; }
        public byte[] ProfilePhoto { get; set; }

    }
}

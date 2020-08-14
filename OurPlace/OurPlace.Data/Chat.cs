using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OurPlace.Data
{
    public class Chat
    {
        public int Id { get; set; }
        [Required]
        public string ChatName { get; set; }
        public List<Message> Messages { get; set; }
    }
}

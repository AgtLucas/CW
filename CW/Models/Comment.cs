using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW.Models
{
    public class Comment
    {
        public int Id { get; set; }

        public string ContentComment { get; set; }

        public DateTime DateOfCreation { get; set; }

        public int PostId { get; set; }
        public Post Post { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }
    }
}
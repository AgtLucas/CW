using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int GroupId { get; set; }
        public Group Group { get; set; }

        public virtual ICollection<Like> Likes { get; set; }
    }
}
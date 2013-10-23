using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW.Models
{
    public class Page
    {
        public int Id { get; set; }
        public string PageName { get; set; }
        public string PageDescription { get; set; }
        public DateTime DateOfCreation { get; set; }

        public int UserOwnerId { get; set; }
        public User User { get; set; }

        public ICollection<Post> Posts { get; set; }
        public virtual ICollection<Like> Likes { get; set; }

    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CW.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        public ICollection<User> Users { get; set; }

        public int UserOwnerId { get; set; }
        public User User { get; set; }
        public ICollection<Post> Posts { get; set; }
    }
}
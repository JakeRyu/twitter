using System.Collections.Generic;
using NUnit.Framework;

namespace Twitter.Domain.Users
{
    public class User
    {
        public User()
        {
            FollowingUsers = new List<User>();
        }
        public string Name { get; set; }
        public List<User> FollowingUsers { get; set; }
    }
}

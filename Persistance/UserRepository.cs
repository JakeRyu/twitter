using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Domain.Users;

namespace Twitter.Persistance
{
    public class UserRepository : IUserRepository
    {
        private readonly List<User> _users;

        public UserRepository()
        {
            _users = new List<User>();
        }

        public void Add(User user)
        {
            _users.Add(user);
        }

        public User Get(string name)
        {
            return _users.Find(u => u.Name == name);
        }
    }
}

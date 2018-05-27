using System;
using System.Collections.Generic;
using Twitter.Application.Interfaces;
using Twitter.Domain.Tweets;
using Twitter.Domain.Users;

namespace Twitter.Persistance
{
    public class UnitOfWork : IUnitOfWork
    {
        public IList<User> Users { get; set; }
        public IList<Tweet> Tweets { get; set; }
        public void SaveChanges()
        {
            throw new NotImplementedException();
        }
    }
}

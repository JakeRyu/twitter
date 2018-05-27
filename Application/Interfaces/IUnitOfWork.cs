using System.Collections.Generic;
using Twitter.Domain.Tweets;
using Twitter.Domain.Users;

namespace Twitter.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IList<User> Users { get; set; }
        IList<Tweet> Tweets { get; set; }
        void SaveChanges();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Domain.Posts;
using Twitter.Domain.Users;

namespace Twitter.Persistance
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> _posts;

        public PostRepository()
        {
            _posts = new List<Post>();
        }

        public void Add(Post post)
        {
            _posts.Add(post);
        }

        public IEnumerable<Post> ListByUser(string username)
        {
            return _posts.Where(p => p.User.Name == username);
        }

        public IEnumerable<Post> ListByUsers(string[] usernames)
        {
            return _posts.Where(p => usernames.Contains(p.User.Name));
        }
    }
}
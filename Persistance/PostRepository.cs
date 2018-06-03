using System;
using System.Collections.Generic;
using NUnit.Framework;
using Twitter.Application.Interfaces;
using Twitter.Domain.Posts;

namespace Twitter.Persistance
{
    public class PostRepository : IPostRepository
    {
        private readonly List<Post> _posts;

        public PostRepository(List<Post> posts)
        {
            _posts = posts;
        }

        public void Add(Post post)
        {
            _posts.Add(post);
        }
    }
}

using System;
using System.Linq;
using Autofac;
using Twitter.Application;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;
using Twitter.Application.Posts.Queries.Wall;
using Twitter.Application.Users.Commands.Follow;

namespace Twitter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            var app = container.Resolve<IApp>();

            app.Run();
        }
    }
}

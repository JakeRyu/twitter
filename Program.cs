using System;
using System.Linq;
using Autofac;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;
using Twitter.Application.Posts.Queries.Wall;
using Twitter.Application.Users.Commands.Follow;

namespace Twitter
{
    public class Program
    {
        private static IContainer _container;

        static void Main(string[] args)
        {
            _container = ContainerConfig.Configure();
            Console.WriteLine("Enter a command. (Hit ENTER to exit)");

            while (true)
            {
                var input = Console.ReadLine();
                if (string.IsNullOrEmpty(input)) break;

                ExecuteCommand(input);
            }
        }

        internal static void ExecuteCommand(string input)
        {
            const int MIN_LENGTH_FOR_ACTION = 1;
            string[] splitted = input.Split(' ');
            if (splitted.Length < MIN_LENGTH_FOR_ACTION) throw new ArgumentException();

            var username = splitted[0];
            var action = splitted.Length == MIN_LENGTH_FOR_ACTION ? "read" : splitted[1];

            switch (action)
            {
                case "->":
                    var message = string.Join(" ", splitted.Skip(2));
                    dynamic args = new {Username = username, Message = message};
                    _container.Resolve<ICreatePostCommand>().Execute(args);
                    break;
                case "follows":
                    var usernameToFollow = splitted[2];
                    _container.Resolve<IFollowUserCommand>().Execute(username, usernameToFollow);
                    break;
                case "wall":
                    var wallPosts = _container.Resolve<IWallQuery>().Execute(username);
                    foreach (var post in wallPosts)
                        Console.WriteLine($"{post.Username} - {post.Message} ({post.WhenPosted})");
                    break;
                case "read":
                    var userPosts = _container.Resolve<IGetPostListByUserQuery>().Execute(username);
                    foreach (var post in userPosts)
                        Console.WriteLine($"{post.Message} ({post.WhenPosted})");
                    break;
                default:
                    throw new Exception("Invalid action entered");
            }
        }
    }
}

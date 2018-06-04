using System;
using System.Linq;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;
using Twitter.Application.Posts.Queries.Wall;
using Twitter.Application.Users.Commands.Follow;

namespace Twitter.Application
{
    public class App : IApp
    {
        private readonly ICreatePostCommand _createPostCommand;
        private readonly IFollowUserCommand _followUserCommand;
        private readonly IWallQuery _wallQuery;
        private readonly IGetPostListByUserQuery _getPostListByUserQuery;

        public App(
            ICreatePostCommand createPostCommand,
            IFollowUserCommand followUserCommand,
            IWallQuery wallQuery,
            IGetPostListByUserQuery getPostListByUserQuery)
        {
            _createPostCommand = createPostCommand;
            _followUserCommand = followUserCommand;
            _wallQuery = wallQuery;
            _getPostListByUserQuery = getPostListByUserQuery;
        }

        public void Run()
        {
            Console.WriteLine("Enter a command. (Hit ENTER to exit)");

            try
            {
                while (true)
                {
                    var input = Console.ReadLine();
                    if (string.IsNullOrEmpty(input)) break;

                    ExecuteCommand(input);
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }

            // for debuggin mode
            Console.ReadLine();
        }

        private void ExecuteCommand(string input)
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
                    dynamic args = new { Username = username, Message = message };
                    _createPostCommand.Execute(args);
                    break;
                case "follows":
                    var usernameToFollow = splitted[2];
                    _followUserCommand.Execute(username, usernameToFollow);
                    break;
                case "wall":
                    var wallPosts = _wallQuery.Execute(username);
                    foreach (var post in wallPosts)
                        Console.WriteLine($"{post.Username} - {post.Message} ({post.WhenPosted})");
                    break;
                case "read":
                    var userPosts = _getPostListByUserQuery.Execute(username);
                    foreach (var post in userPosts)
                        Console.WriteLine($"{post.Message} ({post.WhenPosted})");
                    break;
                default:
                    throw new Exception("Invalid command entered");
            }
        }
    }
}

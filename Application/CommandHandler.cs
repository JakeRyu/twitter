using System;
using System.Linq;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;
using Twitter.Application.Posts.Queries.Wall;
using Twitter.Application.Users.Commands.Follow;

namespace Twitter.Application
{
    public class CommandHandler : ICommandHandler
    {
        private readonly IOutputWriter _writer;
        private readonly ICreatePostCommand _createPostCommand;
        private readonly IFollowUserCommand _followUserCommand;
        private readonly IWallQuery _wallQuery;
        private readonly IGetPostListByUserQuery _getPostListByUserQuery;

        public CommandHandler(
            IOutputWriter writer,
            ICreatePostCommand createPostCommand,
            IFollowUserCommand followUserCommand,
            IWallQuery wallQuery,
            IGetPostListByUserQuery getPostListByUserQuery)
        {
            _writer = writer;
            _createPostCommand = createPostCommand;
            _followUserCommand = followUserCommand;
            _wallQuery = wallQuery;
            _getPostListByUserQuery = getPostListByUserQuery;
        }


        public void ExecuteCommand(string input)
        {
            if (string.IsNullOrEmpty(input)) throw new ArgumentNullException();

            const string noPost = "Nothing posted yet";
            const char separator = ' ';
            string[] splitted = input.Split(separator);

            bool noActionInTheInput = splitted.Length == 1;

            var username = splitted[0];
            var action = noActionInTheInput ? "read" : splitted[1];

            switch (action)
            {
                case "->":
                    var message = string.Join(" ", splitted.Skip(2));
                    _createPostCommand.Execute(username, message);
                    break;
                case "follows":
                    var usernameToFollow = splitted[2];
                    _followUserCommand.Execute(username, usernameToFollow);
                    break;
                case "wall":
                    var wallPosts = _wallQuery.Execute(username);
                    if (wallPosts.Any())
                    {
                        wallPosts.ToList().ForEach(post =>
                            _writer.Write($"{post.Username} - {post.Message} ({post.WhenPosted})"));
                    }
                    else
                    {
                        _writer.Write(noPost);
                    }
                    break;
                case "read":
                    var userPosts = _getPostListByUserQuery.Execute(username);
                    if (userPosts.Any())
                    {
                        userPosts.ToList()
                            .ForEach(post => _writer.Write($"{post.Message} ({post.WhenPosted})"));
                    }
                    else
                    {
                        _writer.Write(noPost);
                    }


                    break;
                default:
                    throw new Exception("Invalid command");
            }
        }
    }
}
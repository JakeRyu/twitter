﻿using System;
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
        private readonly IInputReader _reader;
        private readonly IOutputWriter _writer;
        private readonly ICreatePostCommand _createPostCommand;
        private readonly IFollowUserCommand _followUserCommand;
        private readonly IWallQuery _wallQuery;
        private readonly IGetPostListByUserQuery _getPostListByUserQuery;

        public App(
            IInputReader reader,
            IOutputWriter writer,
            ICreatePostCommand createPostCommand,
            IFollowUserCommand followUserCommand,
            IWallQuery wallQuery,
            IGetPostListByUserQuery getPostListByUserQuery)
        {
            _reader = reader;
            _writer = writer;
            _createPostCommand = createPostCommand;
            _followUserCommand = followUserCommand;
            _wallQuery = wallQuery;
            _getPostListByUserQuery = getPostListByUserQuery;
        }

        public void Run()
        {
            _writer.Write("Enter a command. (Hit ENTER to exit)");

            try
            {
                while (true)
                {
                    var input = _reader.Read();
                    if (string.IsNullOrEmpty(input)) break;

                    ExecuteCommand(input);
                }
            }
            catch (Exception e)
            {
                _writer.Write(e.Message);
            }

            // for debugging mode
            _reader.Read();
        }

        private void ExecuteCommand(string input)
        {
            const int MIN_LENGTH_FOR_ACTION = 1;
            string[] splitted = input.Split(' ');
            if (splitted.Length < MIN_LENGTH_FOR_ACTION) throw new ArgumentException("Invalid command entered");

            var username = splitted[0];
            var action = splitted.Length == MIN_LENGTH_FOR_ACTION ? "read" : splitted[1];

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
                    _wallQuery.Execute(username)
                        .ToList()
                        .ForEach(post => _writer.Write($"{post.Username} - {post.Message} ({post.WhenPosted})"));
                    break;
                case "read":
                    _getPostListByUserQuery.Execute(username)
                        .ToList()
                        .ForEach(post => _writer.Write($"{post.Message} ({post.WhenPosted})"));
                    break;
                default:
                    throw new Exception("Invalid command entered");
            }
        }
    }
}

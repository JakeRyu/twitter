using System;
using System.Linq;
using Autofac;
using Twitter.Application;
using Twitter.Application.Commands;
using Twitter.Application.Interfaces;
using Twitter.Application.Tweets.Commands.Post;

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

                ParseCommand(input).Execute();
            }
        }

        internal static ICommand ParseCommand(string input)
        {
            const int MIN_LENGTH_FOR_ACTION = 1;
            string[] splitted = input.Split(' ');
            if (splitted.Length < MIN_LENGTH_FOR_ACTION) throw new ArgumentException();

            var username = splitted[0];
            var action = splitted.Length == MIN_LENGTH_FOR_ACTION ? "read" : splitted[1];

            ICommand parsedCommand = null;
            switch (action)
            {
                case "->":
                    var message = string.Join(" ", splitted.Skip(2));
                    parsedCommand = _container.Resolve<PostCommand>(
                        new NamedParameter("username", username),
                        new NamedParameter("message", message));
                    break;
                case "follows":
                    var userToFollow = splitted[2];
                    parsedCommand = new FollowCommand(username, userToFollow);
                    break;
                case "wall":
                    parsedCommand = new WallCommand(username);
                    break;
                case "read":
                    parsedCommand = new ReadCommand(username);
                    break;
                default:
                    throw new Exception("Invalid action entered");
            }

            return parsedCommand;
        }
    }
}

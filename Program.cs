using System;
using System.Linq;
using Autofac;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;

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
                    var userToFollow = splitted[2];
                    break;
                case "wall":
                    break;
                case "read":
                    var list = _container.Resolve<IGetPostListByUserQuery>().Execute(username);
                    foreach (var item in list)
                        Console.WriteLine($"{item.Message} ({item.WhenPosted})");
                    break;
                default:
                    throw new Exception("Invalid action entered");
            }
        }
    }
}

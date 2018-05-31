using System;
using System.Linq;
using NUnit.Framework.Constraints;
using Twitter.Application.Commands;
using Twitter.Application.Interfaces;

namespace Twitter.Application
{
    public class CommandLineReader
    {
        public static ICommand Parse(string input)
        {
            string[] splitted = input.Split(' ');
            if(splitted.Length < 1) throw new ArgumentNullException();

            var username = splitted[0];
            var action = splitted[1] ?? "read";

            ICommand parsedCommand = null;
            switch (action)
            {
                case "->":
                    var message = string.Join(" ", splitted.Skip(2));
                    parsedCommand = new PostCommand(username, message);
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
            
            // write tests to see if a correct type is returned based on parsing
            return parsedCommand;
        }
    }
}
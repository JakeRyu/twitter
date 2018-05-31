using System;
using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public class PostCommand : ICommand
    {
        private readonly string _username;
        private readonly string _message;

        public PostCommand(string username, string message)
        {
            _username = username;
            _message = message;
        }

        public void Execute()
        {
            Console.WriteLine($"{_username} said {_message}");
        }
    }
}
using System;
using Twitter.Application.Interfaces;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Quries.GetUserDetail;

namespace Twitter.Application.Commands
{
    public class PostCommand : ICommand
    {
        private readonly string _username;
        private readonly string _message;
        public IGetUserDetailQuery GetUserDetailQuery { get; set; }
        public ICreateUserCommand CreateUserCommand { get; set; }


        public PostCommand(string username, string message)
        {
            _username = username;
            _message = message;
        }

        public void Execute()
        {
            var user = GetUserDetailQuery.Execute(_username);

            if (user == null)
                CreateUserCommand.Execute(new CreateUserModel {Name = _username});

            // save message
        }
    }
}
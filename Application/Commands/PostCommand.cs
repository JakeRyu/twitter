using System;
using Twitter.Application.Interfaces;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Quries.GetUserDetail;

namespace Twitter.Application.Commands
{
    public class PostCommand : Command
    {
        private readonly string _message;
        public IGetUserDetailQuery GetUserDetailQuery { get; set; }
        public ICreateUserCommand CreateUserCommand { get; set; }


        public PostCommand(string username, string message) : base(username)
        {
            _message = message;
        }

        public override void Execute()
        {
            var user = GetUserDetailQuery.Execute(_username);

            if (user == null)
                CreateUserCommand.Execute(new CreateUserModel {Name = _username});

            // save message
        }
    }
}
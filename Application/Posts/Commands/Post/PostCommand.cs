using Twitter.Application.Commands;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Quries.GetUserDetail;
using Twitter.Domain.Users;

namespace Twitter.Application.Posts.Commands.Post
{
    public class PostCommand : Command
    {
        private readonly string _message;
        public IGetUserDetailQuery GetUserDetailQuery { get; set; }
        public ICreateUserCommand CreateUserCommand { get; set; }
        public ICreatePostCommand CreatePostCommand { get; set; }


        public PostCommand(string username, string message) : base(username)
        {
            _message = message;
        }

        public override void Execute()
        {
            var user = GetUserDetailQuery.Execute(_username);

            if (user == null)
                CreateUserCommand.Execute(new CreateUserModel { Name = _username });

            CreatePostCommand.Execute(new CreatePostModel
            {
                User = new User { Name = _username },
                Message = _message
            });
        }
    }
}
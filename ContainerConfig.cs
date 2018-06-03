using Autofac;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Quries.GetUserDetail;
using Twitter.Persistance;

namespace Twitter
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<PostRepository>().As<IPostRepository>();
            builder.RegisterType<CreateUserCommand>().As<ICreateUserCommand>();
            builder.RegisterType<GetUserDetailQuery>().As<IGetUserDetailQuery>();
            builder.RegisterType<CreatePostCommand>().As<ICreatePostCommand>();
            return builder.Build();
        }
    }
}
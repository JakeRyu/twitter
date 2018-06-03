using Autofac;
using Twitter.Application.Commands;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.Post;
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
            builder.RegisterType<PostCommand>().PropertiesAutowired();
            return builder.Build();
        }
    }
}
using Autofac;
using Twitter.Application;
using Twitter.Application.Interfaces;
using Twitter.Application.Posts.Commands.CreatePost;
using Twitter.Application.Posts.Queries.GetPostListByUser;
using Twitter.Application.Posts.Queries.Wall;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Application.Users.Commands.Follow;
using Twitter.Application.Users.Quries.GetUserDetail;
using Twitter.Common.Dates;
using Twitter.Persistance;

namespace Twitter
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<App>().As<IApp>();
            builder.RegisterType<DateService>().As<IDateService>();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();
            builder.RegisterType<PostRepository>().As<IPostRepository>().SingleInstance();
            builder.RegisterType<CreateUserCommand>().As<ICreateUserCommand>();
            builder.RegisterType<GetUserDetailQuery>().As<IGetUserDetailQuery>();
            builder.RegisterType<CreatePostCommand>().As<ICreatePostCommand>();
            builder.RegisterType<GetPostListByUserQuery>().As<IGetPostListByUserQuery>();
            builder.RegisterType<FollowUserCommand>().As<IFollowUserCommand>();
            builder.RegisterType<WallQuery>().As<IWallQuery>();
            return builder.Build();
        }
    }
}
using Autofac;
using Twitter.Application.Interfaces;
using Twitter.Application.Users.Commands.CreateUser;
using Twitter.Persistance;

namespace Twitter
{
    public static class ContainerConfig
    {
        public static IContainer Configure()
        {
            var builder = new ContainerBuilder();
            builder.RegisterType<UserRepository>().As<IUserRepository>();
            builder.RegisterType<CreateUserCommand>().As<ICreateUserCommand>();
            return builder.Build();
        }
    }
}
using Autofac;
using Twitter.Application.Interfaces;

namespace Twitter
{
    public class Program
    {
        static void Main(string[] args)
        {
            var container = ContainerConfig.Configure();

            var app = container.Resolve<IApp>();

            app.Run();
        }
    }
}

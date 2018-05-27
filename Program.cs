using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Autofac;
using Twitter.Domain.Users;

namespace Twitter
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            Container = ContainerConfig.Configure();

            

        }

    }
}

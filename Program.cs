using System;
using Autofac;
using Twitter.Application;

namespace Twitter
{
    public class Program
    {
        private static IContainer Container { get; set; }

        static void Main(string[] args)
        {
            Container = ContainerConfig.Configure();
            Console.WriteLine("Enter a command. (Hit ENTER to exit)");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty) break;

                var result = CommandLineReader.Parse(input);

                // add exception handling
                result.Execute();
            }
        }
    }
}

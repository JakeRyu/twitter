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
            Console.WriteLine("Enter a command. (Hit ENTER to exit)");
            while (true)
            {
                var input = Console.ReadLine();
                if (input == string.Empty) break;

                var result = InputParser.Parse(input);
                result.ExecuteResult();
            }
        }
    }

    public class InputParser
    {
        public static IParsingResult Parse(string input)
        {
            // switch statement expected here
            // identify a command and return a corresponding result
            return new PostingResult("Jake", "Hello");
        }
    }

    public interface IParsingResult
    {
        void ExecuteResult();
    }

    public class PostingResult : IParsingResult
    {
        private readonly string _username;
        private readonly string _message;

        public PostingResult(string username, string message)
        {
            _username = username;
            _message = message;
        }

        public void ExecuteResult()
        {
            Console.WriteLine($"{_username} said {_message}");
        }
    }
}

using System;
using Twitter.Application.Interfaces;

namespace Twitter.Application
{
    public class ConsoleOutputWriter : IOutputWriter
    {
        public void Write(string output)
        {
            Console.WriteLine(output);
        }
    }
}

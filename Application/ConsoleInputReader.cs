using System;
using Twitter.Application.Interfaces;

namespace Twitter.Application
{
    public class ConsoleInputReader : IInputReader
    {
        public string Read()
        {
            return Console.ReadLine();
        }
    }
}
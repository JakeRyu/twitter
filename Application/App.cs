using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Interfaces;

namespace Twitter.Application
{
    public class App : IApp
    {
        private readonly IInputReader _reader;
        private readonly IOutputWriter _writer;
        private readonly ICommandHandler _commandHandler;

        public App(
            IInputReader reader,
            IOutputWriter writer,
            ICommandHandler commandHandler)
        {
            _reader = reader;
            _writer = writer;
            _commandHandler = commandHandler;
        }

        public void Run()
        {
            _writer.Write("Enter a command. (Hit ENTER to exit)");

            while (true)
            {
                var input = _reader.Read();
                if (string.IsNullOrEmpty(input)) break;

                try
                {
                    _commandHandler.ExecuteCommand(input);
                }
                catch (Exception e)
                {
                    _writer.Write(e.Message);
                }
            }


            // for debugging mode
            _reader.Read();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Interfaces;

namespace Twitter.Application.Commands
{
    public abstract class Command : ICommand
    {
        protected string _username;

        public Command(string username)
        {
            _username = username;
        }
        public virtual void Execute()
        {
        }
    }
}

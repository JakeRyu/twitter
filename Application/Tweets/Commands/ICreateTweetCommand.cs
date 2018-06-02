using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Tweets.Commands
{
    public interface ICreateTweetCommand
    {
        void Execute(CreateTweetModel model);
    }
}

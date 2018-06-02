using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Twitter.Application.Interfaces;
using Twitter.Domain.Tweets;

namespace Twitter.Application.Tweets.Commands
{
    public class CreateTweetCommand : ICreateTweetCommand
    {
        private readonly ITweetRepository _tweetRepository;
        public CreateTweetCommand(ITweetRepository tweetRepository)
        {
            _tweetRepository = tweetRepository;
        }
        public void Execute(CreateTweetModel model)
        {
            var tweet = new Tweet
            {
                User = model.User,
                Message = model.Message
            };

            _tweetRepository.Add(tweet);
        }
    }
}

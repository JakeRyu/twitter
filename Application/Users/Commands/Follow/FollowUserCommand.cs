using System;
using Twitter.Application.Interfaces;

namespace Twitter.Application.Users.Commands.Follow
{
    public class FollowUserCommand : IFollowUserCommand
    {
        private readonly IUserRepository _userRepository;

        public FollowUserCommand(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void Execute(string username, string usernameToFollow)
        {
            var user = _userRepository.Get(username);
            if(user == null) throw new ArgumentException("User not exist");

            var userToFollow = _userRepository.Get(usernameToFollow);
            if(userToFollow == null) throw new ArgumentException("Following user not exist");

            user.FollowingUsers.Add(userToFollow);
        }
    }
}
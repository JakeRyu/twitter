using Twitter.Application.Interfaces;

namespace Twitter.Application.Users.Quries.GetUserDetail
{
    public class GetUserDetailQuery : IGetUserDetailQuery
    {
        private readonly IUserRepository _userRepository;

        public GetUserDetailQuery(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserDetailModel Execute(string name)
        {
            var user = _userRepository.Get(name);

            if (user == null) return null;

            return new UserDetailModel
            {
                Name = user.Name
            };
        }
    }
}
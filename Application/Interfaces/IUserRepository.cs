using Twitter.Domain.Users;

namespace Twitter.Application.Interfaces
{
    public interface IUserRepository
    {
        void Add(User user);
    }
}

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Twitter.Application.Users.Commands.Follow
{
    public interface IFollowUserCommand
    {
        void Execute(string username, string usernameToFollow);
    }
}

namespace Twitter.Application.Users.Quries.GetUserDetail
{
    public interface IGetUserDetailQuery
    {
        UserDetailModel Execute(string name);
    }
}

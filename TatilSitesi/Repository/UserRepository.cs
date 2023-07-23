using TatilSitesi.Models;

namespace TatilSitesi.Repository
{
    public class UserRepository : GenericRepository<User>
    {
        Context c = new Context();
        public bool CheckUserName(string UserName)
        {
            var value = c.Users.Any(a => a.UserName == UserName);
            return value;
        }
    }
}

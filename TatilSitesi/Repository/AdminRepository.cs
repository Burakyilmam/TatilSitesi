using TatilSitesi.Models;

namespace TatilSitesi.Repository
{
    public class AdminRepository : GenericRepository<Admin>
    {
        Context c = new Context();
        public bool CheckAdminName(string AdminName)
        {
            var value = c.Admins.Any(a => a.AdminName == AdminName);
            return value;
        }
    }
}

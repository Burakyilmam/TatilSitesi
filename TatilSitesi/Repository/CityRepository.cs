using TatilSitesi.Models;

namespace TatilSitesi.Repository
{
    public class CityRepository : GenericRepository<City>
    {
        Context c = new Context();
        public bool CheckCityName(string CityName)
        {
            var value = c.Cities.Any(a => a.CityName == CityName);
            return value;
        }
    }
}

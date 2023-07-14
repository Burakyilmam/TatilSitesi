using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotelCity : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CityRepository cr = new CityRepository();
            var citylist = cr.List().Where(x => x.CityStatu == true).OrderBy(x => x.CityName); ;
            return View(citylist);
        }
    }
}

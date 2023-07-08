using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListSimilarCityHotel : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var similarhotellist = hr.List("City").Where(x => (x.CityId == id) && (x.HotelStatu == true));
            return View(similarhotellist);
        }
    }
}

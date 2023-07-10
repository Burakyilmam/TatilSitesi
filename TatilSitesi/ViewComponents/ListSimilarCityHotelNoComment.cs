using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListSimilarCityHotelNoComment : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var similarhotellist = hr.List("City", "Category").Where(x => (x.CityId == id) && (x.HotelStatu == true));
            //var city = hr.List("City","Category").FirstOrDefault(x => x.CityId == id);
            //if (city != null)
            //{
            //    ViewBag.CityName = city.City.CityName;
            //}
            return View(similarhotellist);
        }
    }
}

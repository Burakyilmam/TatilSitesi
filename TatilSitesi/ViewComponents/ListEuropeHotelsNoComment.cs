using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListEuropeHotelsNoComment : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var hotelist = hr.List("City", "Category").Where(x => (x.CityId == 4) || (x.CityId == 6) || (x.CityId == 7) && (x.HotelStatu == true));
            return View(hotelist);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListDetailHotel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            HotelRepository hr = new HotelRepository();
            var hotellist = hr.List().Where(x => x.HotelStatu == true);
            return View(hotellist);
        }
    }
}

using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotelDetail : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelDetailRepository hr = new HotelDetailRepository();
            var hoteldetaillist = hr.List("Hotel").Where(x => x.HotelId == id);
            return View(hoteldetaillist);
        }
    }
}

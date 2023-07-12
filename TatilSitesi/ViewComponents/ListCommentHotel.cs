using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListCommentHotel : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            HotelRepository hr = new HotelRepository();
            var hotellist = hr.List().Where(x => x.HotelStatu == true).OrderBy(x => x.HotelName);
            return View(hotellist);
        }
    }
}

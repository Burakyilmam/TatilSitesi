using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotel : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var hotellist = hr.List().Where(x => x.HotelStatu == true && x.HotelId == id );
            return View(hotellist);
        }
    }
}

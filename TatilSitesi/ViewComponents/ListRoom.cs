using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListRoom : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRoomRepository hr = new HotelRoomRepository();
            var hotelroomlist = hr.List().Where(x => (x.HotelId == id) && (x.HotelRoomStatu == true));
            return View(hotelroomlist);
        }
    }
}

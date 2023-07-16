using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotelRoom : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRoomRepository hr = new HotelRoomRepository();
            var hotelroomlist = hr.List().Where(x => (x.HotelRoomId == id) && (x.HotelRoomStatu == true));
            return View(hotelroomlist);
        }
    }
}

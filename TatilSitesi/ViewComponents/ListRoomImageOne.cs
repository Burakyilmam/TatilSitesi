using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListRoomImageOne : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRoomImageRepository hr = new HotelRoomImageRepository();
            return View(hr.List().Where(x => (x.HotelRoomId == id) && (x.HotelRoomImageStatu == true)).Take(1));
        }
    }
}

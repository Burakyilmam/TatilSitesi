using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListRoomImage : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRoomImageRepository hr = new HotelRoomImageRepository();
            return View(hr.List().Where(x => (x.HotelRoomId == id) && (x.HotelRoomImageStatu == true)));
        }
    }
}

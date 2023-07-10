using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotelMinPrice : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRoomRepository hr = new HotelRoomRepository();
            var hotelist = hr.List().Where(x => (x.HotelId == id) && (x.HotelRoomStatu == true)).OrderBy(x => x.HotelRoomPrice).Take(1);
            return View(hotelist);
        }
    }
}

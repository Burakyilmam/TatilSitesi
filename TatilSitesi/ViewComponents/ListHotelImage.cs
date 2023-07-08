using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotelImage : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelImageRepository hr = new HotelImageRepository();
            var hotelimagelist = hr.List().Where(x => (x.HotelId == id) && (x.HotelImageStatu == true));
            return View(hotelimagelist);
        }
    }
}

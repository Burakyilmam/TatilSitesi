using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListSummerHotels : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var similarhotellist = hr.List("City","Category").Where(x => (x.CategoryId == 1) && (x.HotelStatu == true));

            return View(similarhotellist);
        }
    }
}

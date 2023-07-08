using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListSimilarCategoryHotel : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var similarhotellist = hr.List("Category").Where(x => (x.CategoryId == id) && (x.HotelStatu == true));
            return View(similarhotellist);
        }
    }
}

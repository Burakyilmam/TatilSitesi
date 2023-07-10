using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListSimilarCategoryHotelNoComment : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            HotelRepository hr = new HotelRepository();
            var similarhotellist = hr.List("Category", "City").Where(x => (x.CategoryId == id) && (x.HotelStatu == true));

            //var category = hr.List("Category","City").FirstOrDefault(x => x.CategoryId == id);
            //if (category != null)
            //{
            //    ViewBag.CategoryName = category.Category.CategoryName;
            //}
            return View(similarhotellist);
        }
    }
}

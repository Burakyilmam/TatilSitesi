using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListHotelCategory : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            CategoryRepository cr = new CategoryRepository();
            var categorylist = cr.List().Where(x => x.CategoryStatu == true).OrderBy(x => x.CategoryName); ;
            return View(categorylist);
        }
    }
}

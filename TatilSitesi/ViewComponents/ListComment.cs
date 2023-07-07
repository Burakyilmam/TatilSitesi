using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListComment : ViewComponent
    {
        public IViewComponentResult Invoke(int id)
        {
            CommentRepository cr = new CommentRepository();
            var commentlist = cr.List("User").Where(x => (x.HotelId == id) && (x.CommentStatu == true));
            return View(commentlist);
        }
    }
}

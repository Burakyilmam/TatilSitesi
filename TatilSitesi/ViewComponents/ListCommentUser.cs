using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.ViewComponents
{
    public class ListCommentUser : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            UserRepository ur = new UserRepository();
            var userlist = ur.List().Where(x => x.UserStatu == true).OrderBy(x => x.UserName);
            return View(userlist);
        }
    }
}

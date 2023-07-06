using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Repository;

namespace TatilSitesi.Controllers
{
    [AllowAnonymous]
    public class DestinationController : Controller
    {
        DestinationRepository dr = new DestinationRepository();
        public IActionResult DestinationList()
        {
            return View(dr.List());
        }
        public IActionResult DestinationPage(int id,string u)
        {
            ViewBag.Id = id;
            return View(dr.List().Where(x => x.DestinationId == id));
        }
    }
}

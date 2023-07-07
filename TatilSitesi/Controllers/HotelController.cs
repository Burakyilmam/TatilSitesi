using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using TatilSitesi.Repository;

namespace TatilSitesi.Controllers
{
    [AllowAnonymous]
    public class HotelController : Controller
    {
        HotelRepository hr = new HotelRepository();
        public IActionResult HotelPage(int id, string u)
        {
            ViewBag.Id = id;
            return View(hr.List().Where(x => x.HotelId == id));
        }
    }
}
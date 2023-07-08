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
        public IActionResult HotelPage(int id)
        {
            ViewBag.Id = id;
            return View(hr.List("Category","City").Where(x => x.HotelId == id));
        }
    }
}
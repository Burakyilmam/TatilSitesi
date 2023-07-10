using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Globalization;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        HotelRepository hr = new HotelRepository();
        public IActionResult HotelPage(int id)
        {
            ViewBag.Id = id;
            return View(hr.List("Category","City").Where(x => x.HotelId == id));
        }
        [AllowAnonymous]
        public IActionResult HotelPageNoComment(int id)
        {
            ViewBag.Id = id;
            return View(hr.List("Category", "City").Where(x => x.HotelId == id));
        }
        public IActionResult HotelListNoComment(int page = 1)
        {
            return View(hr.List("City", "Category").ToPagedList(page, 12));
        }
    }
}
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
using System.Globalization;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        HotelRepository hr = new HotelRepository();
        public IActionResult HomePage(string p,int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Hotel/HotelListNoComment.cshtml", hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }

            return View();
        }
        [AllowAnonymous]
        public IActionResult HomePageNoComment(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Hotel/HotelListNoComment.cshtml", hr.List("City", "Category").Where(x => (x.HotelName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }

            return View();
        }
    }
}
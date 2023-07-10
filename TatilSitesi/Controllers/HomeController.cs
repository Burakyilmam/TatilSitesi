using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TatilSitesi.Models;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
        [AllowAnonymous]
        public IActionResult HomePageNoComment()
        {
            return View();
        }
    }
}
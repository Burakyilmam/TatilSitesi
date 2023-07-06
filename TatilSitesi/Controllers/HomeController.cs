using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TatilSitesi.Models;

namespace TatilSitesi.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult HomePage()
        {
            return View();
        }
    }
}
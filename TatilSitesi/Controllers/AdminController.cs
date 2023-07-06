using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TatilSitesi.Models;
using TatilSitesi.Repository;

namespace TatilSitesi.Controllers
{
    public class AdminController : Controller
    {
        AdminRepository ar = new AdminRepository();
        Context c = new Context();
        public IActionResult AdminPage()
        {
            var adminIdClaim = HttpContext.User.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier)?.Value;
            if (!string.IsNullOrEmpty(adminIdClaim))
            {
                int userId = int.Parse(adminIdClaim);
                Context c = new Context();
                var user = c.Admins.FirstOrDefault(x => x.AdminId == userId && x.AdminStatu);
                if (user != null)
                {
                    var username = User.Identity.Name;
                    ViewBag.Name = username;
                    ViewBag.Id = userId;
                    return View();
                }
            }
            return RedirectToAction("AdminLogin", "Admin");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminLogin()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AdminLogin(Admin a)
        {
            var value = c.Admins.FirstOrDefault(x => x.AdminName == a.AdminName && x.AdminPassword == a.AdminPassword && x.AdminStatu);
            if (value != null)
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name,a.AdminName),
                    new Claim(ClaimTypes.NameIdentifier, value.AdminId.ToString())
                };
                var adminidentity = new ClaimsIdentity(claims, "a");
                ClaimsPrincipal pr = new ClaimsPrincipal(adminidentity);
                await HttpContext.SignInAsync(pr);
                return RedirectToAction("AdminPage", "Admin");
            }
            return View();
        }
        public async Task<IActionResult> AdminLogoutAsync()
        {
            await HttpContext.SignOutAsync();
            return RedirectToAction("AdminLogin", "Admin");
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult AdminRegister()
        {
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AdminRegister(Admin a)
        {
            a.AdminStatu = true;
            ar.Add(a);
            return RedirectToAction("AdminLogin", "Admin");
        }
    }
}

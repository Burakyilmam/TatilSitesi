using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using System.Security.Claims;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
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
        public async Task<IActionResult> AdminLogout()
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
            bool isAdminExists = ar.CheckAdminName(a.AdminName);

            if (!isAdminExists)
            {
                a.AdminStatu = true;
                ar.Add(a);
                return RedirectToAction("AdminLogin", "Admin");
            }
            else
            {
                ViewData["ErrorMessage"] = "Yönetici Adı Kullanılmaktadır.";
                return View();
            }
        }

    public IActionResult AdminList(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Admin/AdminList.cshtml", ar.List().Where(x => (x.AdminName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(ar.List().ToPagedList(page, 12));
    }
    [HttpGet]
    public IActionResult AdminAdd()
    {
        return View();
    }
    [HttpPost]
    public IActionResult AdminAdd(Admin a)
    {
            bool isAdminExists = ar.CheckAdminName(a.AdminName);

            if (!isAdminExists)
            {
                a.AdminStatu = true;
                ar.Add(a);
                return RedirectToAction("AdminList");
            }
            else
            {
                ViewData["ErrorMessage"] = "Yönetici Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Yönetici Adı Yazınız.";
                return View();
            }
    }
    public IActionResult AdminDelete(int id)
    {
        ar.Delete(new Admin { AdminId = id });
        return RedirectToAction("AdminList");
    }
    public IActionResult GetAdmin(int id)
    {
        var Admin = ar.Get(id);
        Admin c = new Admin()
        {
            AdminId = Admin.AdminId,
            AdminName = Admin.AdminName,
            AdminPassword = Admin.AdminPassword,
            AdminStatu = Admin.AdminStatu
        };
        return View(c);
    }
    public IActionResult AdminUpdate(Admin c)
    {
        var Admin = ar.Get(c.AdminId);
        Admin.AdminName = c.AdminName;
        Admin.AdminPassword = c.AdminPassword;
        Admin.AdminStatu = c.AdminStatu;
        ar.Update(Admin);
        return RedirectToAction("AdminList");
    }
}
}
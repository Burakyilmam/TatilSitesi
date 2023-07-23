using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryRepository cr = new CategoryRepository();
        public IActionResult CategoryList(string p, int page = 1)
        {
            if (!string.IsNullOrEmpty(p))
            {
                return View("~/Views/Category/CategoryList.cshtml", cr.List().Where(x => (x.CategoryName.Contains((CultureInfo.CurrentCulture.TextInfo.ToTitleCase(p.ToLower()))))).ToPagedList(page, 12));
            }
            return View(cr.List().ToPagedList(page, 12));
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category c)
        {
            bool isCategoryExists = cr.CheckCategoryName(c.CategoryName);

            if (!isCategoryExists)
            {
                c.CategoryStatu = true;
                cr.Add(c);
                return RedirectToAction("CategoryList");
            }
            else
            {
                ViewData["ErrorMessage"] = "Kategori Adı Kullanılmaktadır. Lütfen Aşağıdaki Alana Veritabanında Bulunmayan Bir Kategori Adı Yazınız.";
                return View();
            }
        }
        public IActionResult CategoryDelete(int id)
        {
            cr.Delete(new Category { CategoryId = id });
            return RedirectToAction("CategoryList");
        }
        public IActionResult GetCategory(int id)
        {
            var category = cr.Get(id);
            Category c = new Category()
            {
                CategoryId = category.CategoryId,
                CategoryName = category.CategoryName,
                CategoryStatu = category.CategoryStatu
            };
            return View(c);
        }
        public IActionResult CategoryUpdate(Category c)
        {
            var category = cr.Get(c.CategoryId);
            category.CategoryName = c.CategoryName;
            category.CategoryStatu = c.CategoryStatu;
            category.CategoryId = c.CategoryId;
            cr.Update(category);
            return RedirectToAction("CategoryList");
        }
    }
}

using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TatilSitesi.Models;
using TatilSitesi.Repository;
using X.PagedList;

namespace TatilSitesi.Controllers
{
    [Authorize]
    public class CategoryController : Controller
    {
        CategoryRepository cr = new CategoryRepository();
        public IActionResult CategoryList(int page = 1)
        {
            return View(cr.List().ToPagedList(page, 8));
        }
        [HttpGet]
        public IActionResult CategoryAdd()
        {
            return View();
        }
        [HttpPost]
        public IActionResult CategoryAdd(Category c)
        {
            c.CategoryStatu = true;
            cr.Add(c);
            return RedirectToAction("CategoryList");
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

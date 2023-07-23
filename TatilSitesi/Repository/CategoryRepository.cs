using TatilSitesi.Models;

namespace TatilSitesi.Repository
{
    public class CategoryRepository : GenericRepository<Category>
    {
        Context c = new Context();
        public bool CheckCategoryName(string CategoryName)
        {
            var value = c.Categories.Any(a => a.CategoryName == CategoryName);
            return value;
        }
    }
}

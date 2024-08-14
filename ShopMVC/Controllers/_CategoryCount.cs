using Microsoft.AspNetCore.Mvc;
using ShopMVC.Data;
using ShopMVC.Models;

namespace ShopMVC.Controllers
{
    [ViewComponent(Name = "_CategoryCount")]
    public class _CategoryCount : ViewComponent
    {
        private readonly ShopMVCContext _context;

        public _CategoryCount(ShopMVCContext context)
        {
            _context = context;
        }
        public IViewComponentResult Invoke()
        {
            var _Category = _context.Category.ToList();
            List<Dictionary<Category, int>> categoryProductCounts = new List<Dictionary<Category, int>>();


            for (int i = 0; i < _Category.Count; i++)
            {
                Dictionary<Category, int> subList = new Dictionary<Category, int>();

                var category = _Category[i];
                int productCount = _context.Product.Count(p => p.CategoryId == category.CategoryId);
                subList[category] = productCount;

                categoryProductCounts.Add(subList);
            }
            return View("_CategoryCount", categoryProductCounts);
        }
    }
}

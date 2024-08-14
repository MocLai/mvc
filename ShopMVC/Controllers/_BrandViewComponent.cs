using Microsoft.AspNetCore.Mvc;
using ShopMVC.Data;
using ShopMVC.Models;

namespace ShopMVC.Controllers
{
	[ViewComponent(Name = "_Brand")]
	public class _BrandViewComponent : ViewComponent
	{
		private readonly ShopMVCContext _context;

		public _BrandViewComponent(ShopMVCContext context)
		{
			_context = context;
		}
		public IViewComponentResult Invoke()
		{
			var _Brand = _context.Brand.ToList();
			List<Dictionary<Brand, int>> brandProductCounts = new List<Dictionary<Brand, int>>();


			for (int i = 0; i < _Brand.Count; i++)
			{
				Dictionary<Brand, int> subList = new Dictionary<Brand, int>();

				var brand = _Brand[i];
				int productCount = _context.Product.Count(p => p.BrandId == brand.BrandId);
				subList[brand] = productCount;
				
				brandProductCounts.Add(subList);
			}
			return View("_Brand", brandProductCounts);
		}
	}
}

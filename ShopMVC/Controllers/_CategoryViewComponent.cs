using Microsoft.AspNetCore.Mvc;
using ShopMVC.Data;

namespace ShopMVC.Controllers
{
	[ViewComponent(Name = "_Category")]
	public class _CategoryViewComponent : ViewComponent
	{
		private readonly ShopMVCContext _context;

		public _CategoryViewComponent(ShopMVCContext context)
		{
			_context = context;
		}	
		public IViewComponentResult Invoke()
		{
			var _Category = _context.Category.ToList();
			return View("_Category", _Category);
		}
	}
}

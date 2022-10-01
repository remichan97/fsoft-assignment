using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
	public class PostController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}

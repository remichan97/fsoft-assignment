using FA.JustBlog.Models;
using FA.JustBlog.Services.Post;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace FA.JustBlog.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		private readonly IPostService _postService;

		public HomeController(ILogger<HomeController> logger, IPostService postService)
		{
			_logger = logger;
			this._postService = postService;
		}

		public async Task<IActionResult> Index()
		{
			var model = await _postService.GetLatestPosts(3);
			return View(model);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
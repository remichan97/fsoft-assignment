using FA.JustBlog.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
	public class TagController : Controller
	{
		private readonly IPostService _postService;

		public TagController(IPostService postService)
		{
			this._postService = postService;
		}

		public async Task<IActionResult> Index(string name)
		{
			var model = await _postService.GetPostsByTag(name);
			TempData["tagName"] = name;
			return View(model);
		}
	}
}
using FA.JustBlog.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
	public class PostController : Controller
	{
		private readonly IPostService _postService;

		public PostController(IPostService postService)
		{
			this._postService = postService;
		}

		public IActionResult Index()
		{
			var model = _postService.GetAllPosts();
			return View(model);
		}
	}
}

using FA.JustBlog.Services.Post;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IPostService _postService;

        public CategoryController(IPostService postService)
        {
            this._postService = postService;
        }

        public async Task<IActionResult> Index(string name)
        {
            var model = await _postService.GetPostsByCategory(name);
            TempData["catName"] = name;
            return View(model);
        }
    }
}

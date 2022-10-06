using FA.JustBlog.Common.Constants;
using FA.JustBlog.Services.Category;
using FA.JustBlog.Services.Post;
using FA.JustBlog.Services.Tag;
using FA.JustBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = Role.BlogOwner + "," + Role.Contributor)]
	public class PostsController : Controller
	{
		private readonly IPostService _postService;
		private readonly ITagService _tagService;
		private readonly ICategoryService _categoryService;

		public PostsController(IPostService postService, ITagService tagService, ICategoryService categoryService)
		{
			this._postService = postService;
			this._tagService = tagService;
			this._categoryService = categoryService;
		}

		// GET: Admin/Posts
		public async Task<IActionResult> Index()
		{
			var model = await _postService.GetAllPosts();
			return View(model);
		}
		public async Task<IActionResult> Latest()
		{
			var model = await _postService.GetLatestPosts(5);
			return View(model);
		}

		public async Task<IActionResult> MostViewed()
		{
			var model = await _postService.GetMostViewedPosts(5);
			return View(model);
		}

		public async Task<IActionResult> Interesting()
		{
			var model = await _postService.GetMostInterestingPosts(5);
			return View(model);
		}

		public async Task<IActionResult> Published()
		{
			var model = await _postService.GetPublishedPosts();
			return View(model);
		}

		public async Task<IActionResult> Unpublished()
		{
			var model = await _postService.GetUnpublishedPosts();
			return View(model);
		}

		// GET: Admin/Posts/Create
		public async Task<IActionResult> CreateAsync()
		{
			ViewData["CategoriesId"] = await _categoryService.GetSelectListItems();
			ViewData["TagsId"] = await _tagService.GetSelectListItems();
			return View();
		}

		// POST: Admin/Posts/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Title,ShortDescription,Meta,Published,CategoriesId,PostContent,TagId")] PostCreateVM posts)
		{
			if (ModelState.IsValid)
			{
				await _postService.AddPost(posts);
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoriesId"] = await _categoryService.GetSelectListItems();
			ViewData["TagsId"] = await _tagService.GetSelectListItems();
			return View(posts);
		}

		// GET: Admin/Posts/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var posts = await _postService.FindPostById(id.Value);
			if (posts == null)
			{
				return NotFound();
			}

			var model = new PostCreateVM();

			model.Title = posts.Title;
			model.ShortDescription = posts.ShortDescription;
			model.Meta = posts.Meta;
			model.Published = posts.Published;
			model.CategoriesId = posts.CategoriesId;
			model.TagId = posts.PostTags.Select(it => it.TagId).ToList();
			
			model.PostContent = posts.PostContent;

			ViewData["CategoriesId"] = await _categoryService.GetSelectListItems();
			ViewData["TagsId"] = await _tagService.GetSelectListItems();
			TempData["PostId"] = id;
			return View(model);
		}

		// POST: Admin/Posts/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Title,ShortDescription,Meta,Published,CategoriesId,PostContent,TagId")] PostCreateVM posts)
		{

			if (ModelState.IsValid)
			{
				try
				{
					await _postService.EditPost(posts, id);
					return RedirectToAction(nameof(Index));
				}
				catch (InvalidOperationException ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
				return RedirectToAction(nameof(Index));
			}
			ViewData["CategoriesId"] = await _categoryService.GetSelectListItems();
			ViewData["TagsId"] = await _tagService.GetSelectListItems();
			TempData["PostId"] = id;
			return View(posts);
		}

		// GET: Admin/Posts/Delete/5
		[Authorize(Roles = Role.BlogOwner)]
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var posts = await _postService.FindPostById(id.Value);
			if (posts == null)
			{
				return NotFound();
			}

			return View(posts);
		}

		// POST: Admin/Posts/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		[Authorize(Roles = Role.BlogOwner)]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var posts = await _postService.FindPostById(id);

			if (posts != null)
			{
				await _postService.DeletePost(id);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
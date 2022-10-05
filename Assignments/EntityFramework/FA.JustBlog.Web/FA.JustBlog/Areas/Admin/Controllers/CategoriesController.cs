using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Category;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class CategoriesController : Controller
	{
		private readonly ICategoryService _categoryService;

		public CategoriesController(ICategoryService categoryService)
		{
			this._categoryService = categoryService;
		}

		// GET: Admin/Categories
		public async Task<IActionResult> Index()
		{
			return View(await _categoryService.GetAllCategories());
		}

		// GET: Admin/Categories/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Categories/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,UrlSlug,Description")] Categories categories)
		{
			if (ModelState.IsValid)
			{
				categories.Id = Guid.NewGuid();
				await _categoryService.AddCategory(categories);
				return RedirectToAction(nameof(Index));
			}
			return View(categories);
		}

		// GET: Admin/Categories/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var categories = await _categoryService.CheckExist(id.Value);
			if (categories == null)
			{
				return NotFound();
			}
			return View(categories);
		}

		// POST: Admin/Categories/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,UrlSlug,Description")] Categories categories)
		{
			if (id != categories.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					await _categoryService.EditCategory(categories);
				}
				catch (DbUpdateConcurrencyException)
				{
					//if (!CategoriesExists(categories.Id))
					//{
					//	return NotFound();
					//}
					//else
					//{
					//	throw;
					//}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(categories);
		}

		// GET: Admin/Categories/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var categories = await _categoryService.CheckExist(id.Value);
			if (categories == null)
			{
				return NotFound();
			}

			return View(categories);
		}

		// POST: Admin/Categories/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var categories = await _categoryService.CheckExist(id);
			if (categories != null)
			{
				await _categoryService.DeleteCategory(id);
			}

			return RedirectToAction(nameof(Index));
		}
	}
}
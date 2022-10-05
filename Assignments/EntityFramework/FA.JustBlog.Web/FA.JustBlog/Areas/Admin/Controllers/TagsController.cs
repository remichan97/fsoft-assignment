using FA.JustBlog.Common.Constants;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Tag;
using FA.JustBlog.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = Role.BlogOwner + "," + Role.Contributor)]
	public class TagsController : Controller
	{
		private readonly ITagService _tagService;

		public TagsController(ITagService tagService)
		{
			this._tagService = tagService;
		}

		// GET: Admin/Tags
		public async Task<IActionResult> Index()
		{
			return View(await _tagService.GetAllTags());
		}
		// GET: Admin/Tags/Create
		public IActionResult Create()
		{
			return View();
		}

		// POST: Admin/Tags/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("Id,Name,Description")] TagCreateVM tags)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await _tagService.AddTag(tags);
					return RedirectToAction(nameof(Index));
				}
				catch (InvalidOperationException ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			return View(tags);
		}

		// GET: Admin/Tags/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tags = await _tagService.CheckExists(id.Value);
			if (tags == null)
			{
				return NotFound();
			}

			var data = new TagCreateVM { Name = tags.Name, Description = tags.Description };
			TempData["TagId"] = id;
			return View(data);
		}

		// POST: Admin/Tags/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Name,Description")] TagCreateVM tags)
		{
			if (ModelState.IsValid)
			{
				try
				{
					await _tagService.EditTag(tags, id);
					return RedirectToAction(nameof(Index));
				}
				catch (InvalidOperationException ex)
				{
					ModelState.AddModelError(string.Empty, ex.Message);
				}
			}
			TempData["TagId"] = id;
			return View(tags);
		}

		// GET: Admin/Tags/Delete/5
		[Authorize(Roles = Role.BlogOwner)]
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var tags = await _tagService.CheckExists(id.Value);
			if (tags == null)
			{
				return NotFound();
			}

			return View(tags);
		}

		// POST: Admin/Tags/Delete/5
		[HttpPost, ActionName("Delete")]
		[Authorize(Roles = Role.BlogOwner)]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			var tags = await _tagService.CheckExists(id);

			if (tags != null)
			{
				await _tagService.DeleteTag(id);
			}

			return RedirectToAction(nameof(Index));
		}

	}
}
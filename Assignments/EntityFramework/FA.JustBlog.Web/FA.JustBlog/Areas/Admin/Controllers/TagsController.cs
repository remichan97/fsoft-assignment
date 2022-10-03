using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	public class TagsController : Controller
	{
		private readonly AppDbContext _context;

		public TagsController(AppDbContext context)
		{
			_context = context;
		}

		// GET: Admin/Tags
		public async Task<IActionResult> Index()
		{
			return View(await _context.Tags.ToListAsync());
		}

		// GET: Admin/Tags/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null || _context.Tags == null)
			{
				return NotFound();
			}

			var tags = await _context.Tags
				.FirstOrDefaultAsync(m => m.Id == id);
			if (tags == null)
			{
				return NotFound();
			}

			return View(tags);
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
		public async Task<IActionResult> Create([Bind("Id,Name,UrlSlug,Description,Count")] Tags tags)
		{
			if (ModelState.IsValid)
			{
				tags.Id = Guid.NewGuid();
				_context.Add(tags);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(tags);
		}

		// GET: Admin/Tags/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null || _context.Tags == null)
			{
				return NotFound();
			}

			var tags = await _context.Tags.FindAsync(id);
			if (tags == null)
			{
				return NotFound();
			}
			return View(tags);
		}

		// POST: Admin/Tags/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,UrlSlug,Description,Count")] Tags tags)
		{
			if (id != tags.Id)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(tags);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!TagsExists(tags.Id))
					{
						return NotFound();
					}
					else
					{
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(tags);
		}

		// GET: Admin/Tags/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null || _context.Tags == null)
			{
				return NotFound();
			}

			var tags = await _context.Tags
				.FirstOrDefaultAsync(m => m.Id == id);
			if (tags == null)
			{
				return NotFound();
			}

			return View(tags);
		}

		// POST: Admin/Tags/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
		{
			if (_context.Tags == null)
			{
				return Problem("Entity set 'AppDbContext.Tags'  is null.");
			}
			var tags = await _context.Tags.FindAsync(id);
			if (tags != null)
			{
				_context.Tags.Remove(tags);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool TagsExists(Guid id)
		{
			return _context.Tags.Any(e => e.Id == id);
		}
	}
}
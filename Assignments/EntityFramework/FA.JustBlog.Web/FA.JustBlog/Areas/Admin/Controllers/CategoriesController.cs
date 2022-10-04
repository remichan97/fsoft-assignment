using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize]
	public class CategoriesController : Controller
	{
		private readonly AppDbContext _context;

		public CategoriesController(AppDbContext context)
		{
			_context = context;
		}

		// GET: Admin/Categories
		public async Task<IActionResult> Index()
		{
			return View(await _context.Categories.ToListAsync());
		}

		// GET: Admin/Categories/Details/5
		public async Task<IActionResult> Details(Guid? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var categories = await _context.Categories
				.FirstOrDefaultAsync(m => m.Id == id);
			if (categories == null)
			{
				return NotFound();
			}

			return View(categories);
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
				_context.Add(categories);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(categories);
		}

		// GET: Admin/Categories/Edit/5
		public async Task<IActionResult> Edit(Guid? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var categories = await _context.Categories.FindAsync(id);
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
					_context.Update(categories);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!CategoriesExists(categories.Id))
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
			return View(categories);
		}

		// GET: Admin/Categories/Delete/5
		public async Task<IActionResult> Delete(Guid? id)
		{
			if (id == null || _context.Categories == null)
			{
				return NotFound();
			}

			var categories = await _context.Categories
				.FirstOrDefaultAsync(m => m.Id == id);
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
			if (_context.Categories == null)
			{
				return Problem("Entity set 'AppDbContext.Categories'  is null.");
			}
			var categories = await _context.Categories.FindAsync(id);
			if (categories != null)
			{
				_context.Categories.Remove(categories);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool CategoriesExists(Guid id)
		{
			return _context.Categories.Any(e => e.Id == id);
		}
	}
}
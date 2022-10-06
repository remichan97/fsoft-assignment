using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Common.Constants;
using Microsoft.AspNetCore.Authorization;

namespace FA.JustBlog.Areas.Admin.Controllers
{
    [Area("Admin")]
	public class CommentsController : Controller
    {
        private readonly AppDbContext _context;

        public CommentsController(AppDbContext context)
        {
            _context = context;
        }

		// GET: Admin/Comments
		[Authorize]
		public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Comments.Include(c => c.Posts);
            return View(await appDbContext.ToListAsync());
        }

		// GET: Admin/Comments/Details/5
		[Authorize]
		public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .Include(c => c.Posts)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

		// GET: Admin/Comments/Create
		[Authorize(Roles = Role.BlogOwner + "," + Role.Contributor)]
		public IActionResult Create()
        {
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Meta");
            return View();
        }

        // POST: Admin/Comments/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = Role.BlogOwner + "," + Role.Contributor)]
		public async Task<IActionResult> Create([Bind("Id,Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comments comments)
        {
            if (ModelState.IsValid)
            {
                comments.Id = Guid.NewGuid();
                _context.Add(comments);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Meta", comments.PostId);
            return View(comments);
        }

		// GET: Admin/Comments/Edit/5
		[Authorize(Roles = Role.BlogOwner + "," + Role.Contributor)]
		public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments.FindAsync(id);
            if (comments == null)
            {
                return NotFound();
            }
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Meta", comments.PostId);
            return View(comments);
        }

        // POST: Admin/Comments/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = Role.BlogOwner + "," + Role.Contributor)]
		public async Task<IActionResult> Edit(Guid id, [Bind("Id,Name,Email,PostId,CommentHeader,CommentText,CommentTime")] Comments comments)
        {
            if (id != comments.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(comments);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CommentsExists(comments.Id))
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
            ViewData["PostId"] = new SelectList(_context.Posts, "Id", "Meta", comments.PostId);
            return View(comments);
        }

		// GET: Admin/Comments/Delete/5
		[Authorize(Roles = Role.BlogOwner)]
		public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null || _context.Comments == null)
            {
                return NotFound();
            }

            var comments = await _context.Comments
                .Include(c => c.Posts)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (comments == null)
            {
                return NotFound();
            }

            return View(comments);
        }

        // POST: Admin/Comments/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
		[Authorize(Roles = Role.BlogOwner)]
		public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            if (_context.Comments == null)
            {
                return Problem("Entity set 'AppDbContext.Comments'  is null.");
            }
            var comments = await _context.Comments.FindAsync(id);
            if (comments != null)
            {
                _context.Comments.Remove(comments);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CommentsExists(Guid id)
        {
          return _context.Comments.Any(e => e.Id == id);
        }
    }
}

using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repository
{
	public class CategoriesRepository : BaseRepository<Categories>, ICategoriesRepository
	{
		public CategoriesRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Categories> CheckExists(Guid id)
		{
			return await _DbContext.Categories.FirstOrDefaultAsync(it => it.Id.Equals(id));
		}

		public async Task<IList<Categories>> GetCategories()
		{
			return await _DbContext.Categories.ToListAsync();
		}
	}
}
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.IRepository
{
	public interface ICategoriesRepository : IBaseRepository<Categories>
	{
		Task<IList<Categories>> GetCategories();
		Task<Categories> CheckExists(Guid id);
	}
}
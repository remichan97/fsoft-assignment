using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.IRepository
{
	public interface ITagsRepository : IBaseRepository<Tags>
	{
		Task<IList<Tags>> GetAllTags();
		Task<Tags> GetTagsByUrlSlugs(string urlSlugs);
		Task<Tags> CheckExists(string name);
		Task<Tags> CheckExists(Guid id);
	}
}
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repository
{
	public class TagsRepository : BaseRepository<Tags>, ITagsRepository
	{
		public TagsRepository(AppDbContext context) : base(context)
		{
		}

		public Tags GetTagsByUrlSlugs(string urlSlugs)
		{
			return _DbContext.Tags.FirstOrDefault(it => it.UrlSlug.Equals(urlSlugs));
		}
	}
}
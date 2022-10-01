using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repository
{
	public class TagsRepository : BaseRepository<Tags>, ITagsRepository
	{
		public TagsRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Tags> GetTagsByUrlSlugs(string urlSlugs)
		{
			return await _DbContext.Tags.FirstOrDefaultAsync(it => it.UrlSlug.Equals(urlSlugs));
		}
	}
}
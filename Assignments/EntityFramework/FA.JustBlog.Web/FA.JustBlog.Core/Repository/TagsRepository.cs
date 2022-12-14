using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace FA.JustBlog.Core.Repository
{
	public class TagsRepository : BaseRepository<Tags>, ITagsRepository
	{
		public TagsRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<Tags> CheckExists(string name)
		{
			return await _DbContext.Tags.FirstOrDefaultAsync(it => it.Name.Equals(name));
		}

		public async Task<Tags> CheckExists(Guid id)
		{
			return await _DbContext.Tags.FirstOrDefaultAsync(it => it.Id.Equals(id));

		}

		public async Task<IList<Tags>> GetAllTags()
		{
			return await _DbContext.Tags.ToListAsync();
		}

		public async Task<Tags> GetTagsByUrlSlugs(string urlSlugs)
		{
			return await _DbContext.Tags.FirstOrDefaultAsync(it => it.UrlSlug.Equals(urlSlugs));
		}
	}
}
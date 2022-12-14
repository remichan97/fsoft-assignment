using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Repository
{
	public class PostsRepository : BaseRepository<Posts>, IPostsRepository
	{
		public PostsRepository(AppDbContext context) : base(context)
		{
		}

		public async Task<IList<Posts>> GetPublishedPosts()
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).ThenInclude(it => it.Tags).Where(it => it.Published == true).ToListAsync();
		}

		public async Task<IList<Posts>> GetUnpublishedPosts()
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).ThenInclude(it => it.Tags).Where(it => it.Published == false).ToListAsync();
		}

		public async Task<IList<Posts>> GetLatestPosts(int size)
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).ThenInclude(it => it.Tags).OrderByDescending(it => it.PostedOn).Where(it => it.Published == true).Take(size).ToListAsync();
		}

		public async Task<IList<Posts>> GetPostsByMonth(DateTime monthYear)
		{
			return await _DbContext.Posts.Where(it => it.PostedOn.Month == monthYear.Month).ToListAsync();
		}

		public int CountPostsByCategory(string category)
		{
			return _DbContext.Posts.Count(it => it.Categories.Name.Equals(category));
		}

		public async Task<IList<Posts>> GetPostsByCategory(string category)
		{
			return await _DbContext.Posts.Where(it => it.Categories.Name.Equals(category) && it.Published == true).ToListAsync();
		}

		public int CountPostsByTag(string tag)
		{
			var query = from data in _DbContext.Posts join pt in _DbContext.PostTags on data.Id equals pt.PostId join tags in _DbContext.Tags on pt.TagId equals tags.Id where tags.Name.Equals(tag) select data;

			return query.Count();
		}

		public async Task<IList<Posts>> GetPostsByTag(string tag)
		{
			var query = from data in _DbContext.Posts join pt in _DbContext.PostTags on data.Id equals pt.PostId join tags in _DbContext.Tags on pt.TagId equals tags.Id where tags.Name.Equals(tag) select data;

			return await query.ToListAsync();
		}

		public async Task<Posts> FindPost(int year, int month, string urlSlug)
		{
			return await _DbContext.Posts.FirstOrDefaultAsync(it => it.PostedOn.Year == year && it.PostedOn.Month == month && it.UrlSlug.Equals(urlSlug));
		}

		public async Task<IList<Posts>> GetMostViewedPosts(int size)
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).ThenInclude(it => it.Tags).OrderByDescending(it => it.ViewCount).Where(it => it.Published == true).Take(size).ToListAsync();
		}

		public async Task<IList<Posts>> GetAllPosts()
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).ThenInclude(it => it.Tags).ToListAsync();
		}

		public async Task<Posts> FindPost(Guid id)
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).FirstOrDefaultAsync(it => it.Id.Equals(id));
		}

		public async Task<IList<Posts>> GetMostInterestingPosts(int size)
		{
			return await _DbContext.Posts.Include(it => it.Categories).Include(it => it.PostTags).ThenInclude(it => it.Tags).OrderByDescending(it => it.TotalRate).Take(size).ToListAsync();
		}
	}
}
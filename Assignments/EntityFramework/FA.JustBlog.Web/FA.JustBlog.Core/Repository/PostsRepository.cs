using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repository
{
	public class PostsRepository : BaseRepository<Posts>, IPostsRepository
	{
		public PostsRepository(AppDbContext context) : base(context)
		{
		}

		public IList<Posts> GetPublishedPosts()
		{
			return _DbContext.Posts.Where(it => it.Published == true).ToList();
		}

		public IList<Posts> GetUnpublishedPosts()
		{
			return _DbContext.Posts.Where(it => it.Published == false).ToList();
		}

		public IList<Posts> GetLatestPosts(int size)
		{
			return _DbContext.Posts.OrderByDescending(it => it.PostedOn).Take(size).ToList();
		}

		public IList<Posts> GetPostsByMonth(DateTime monthYear)
		{
			return _DbContext.Posts.Where(it => it.PostedOn.Month == monthYear.Month).ToList();
		}

		public int CountPostsByCategory(string category)
		{
			return _DbContext.Posts.Count(it => it.Categories.Name.Equals(category));
		}

		public IList<Posts> GetPostsByCategory(string category)
		{
			return _DbContext.Posts.Where(it => it.Categories.Name.Equals(category)).ToList();
		}

		public int CountPostsByTag(string tag)
		{
			var query = from data in _DbContext.Posts join pt in _DbContext.PostTags on data.Id equals pt.PostId join tags in _DbContext.Tags on pt.TagId equals tags.Id where tags.Name.Equals(tag) select data;

			return query.Count();
		}

		public IList<Posts> GetPostsByTag(string tag)
		{
			var query = from data in _DbContext.Posts join pt in _DbContext.PostTags on data.Id equals pt.PostId join tags in _DbContext.Tags on pt.TagId equals tags.Id where tags.Name.Equals(tag) select data;

			return query.ToList();
		}

		public Posts FindPost(int year, int month, string urlSlug)
		{
			return _DbContext.Posts.FirstOrDefault(it => it.PostedOn.Year == year && it.PostedOn.Month == month && it.UrlSlug.Equals(urlSlug));
		}
	}
}
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.IRepository
{
	public interface IPostsRepository : IBaseRepository<Posts>
	{
		Task<IList<Posts>> GetAllPosts();

		Task<IList<Posts>> GetPublishedPosts();
		Task<IList<Posts>> GetUnpublishedPosts();

		Task<IList<Posts>> GetLatestPosts(int size);

		Task<IList<Posts>> GetMostViewedPosts(int size);

		Task<IList<Posts>> GetMostInterestingPosts(int size);

		Task<IList<Posts>> GetPostsByMonth(DateTime monthYear);

		int CountPostsByCategory(string category);

		Task<IList<Posts>> GetPostsByCategory(string category);

		int CountPostsByTag(string tag);

		Task<IList<Posts>> GetPostsByTag(string tag);

		Task<Posts> FindPost(int year, int month, string urlSlug);
		Task<Posts> FindPost(Guid id);

	}
}
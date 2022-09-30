using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.IRepository
{
	public interface IPostsRepository : IBaseRepository<Posts>
	{
		IList<Posts> GetPublishedPosts();
		IList<Posts> GetUnpublishedPosts();
		IList<Posts> GetLatestPosts(int size);
		IList<Posts> GetPostsByMonth(DateTime monthYear);
		int CountPostsByCategory(string category);
		IList<Posts> GetPostsByCategory(string category);
		int CountPostsByTag(string tag);
		IList<Posts> GetPostsByTag(string tag);
		Posts FindPost(int year, int month, string urlSlug);
	}
}
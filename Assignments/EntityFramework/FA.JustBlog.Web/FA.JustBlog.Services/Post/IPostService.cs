using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Services.Post
{
	public interface IPostService
	{
		Task<IEnumerable<Posts>> GetAllPosts();

		Task<IEnumerable<Posts>> GetLatestPosts(int size);

		Task<IEnumerable<Posts>> GetMostViewedPosts(int size);

		Task<IEnumerable<Posts>> GetPostsByCategory(string name);

		Task<IEnumerable<Posts>> GetPostsByTag(string name);

		Task<Posts> GetPostsDetails(Guid id);

		Task<Posts> GetPostsDetails(int year, int month, string title);
	}
}
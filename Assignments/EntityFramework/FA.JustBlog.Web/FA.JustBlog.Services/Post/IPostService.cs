using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;

namespace FA.JustBlog.Services.Post
{
	public interface IPostService
	{
		Task<IEnumerable<Posts>> GetAllPosts();
		Task<IEnumerable<Posts>> GetPublishedPosts();
		Task<IEnumerable<Posts>> GetLatestPosts(int size);

		Task<IEnumerable<Posts>> GetMostViewedPosts(int size);

		Task<IEnumerable<Posts>> GetPostsByCategory(string name);

		Task<IEnumerable<Posts>> GetPostsByTag(string name);

		Task<Posts> GetPostsDetails(Guid id);

		Task<Posts> GetPostsDetails(int year, int month, string title);

		Task AddPost(PostCreateVM post);

		Task EditPost(PostCreateVM post, Guid id);

		Task DeletePost(Guid postId);

		Task<Posts> FindPostById(Guid id);
	}
}
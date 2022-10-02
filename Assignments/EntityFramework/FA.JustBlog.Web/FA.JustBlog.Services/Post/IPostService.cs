using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Post
{
	public interface IPostService
	{
		Task<IEnumerable<Posts>> GetAllPosts();
		Task<IEnumerable<Posts>> GetLatestPosts(int size);
		Task<IEnumerable<Posts>> GetMostViewedPosts(int size);
		Task<Posts> GetPostsDetails(Guid id);
		Task<Posts> GetPostsDetails(int year, int month, string title);
	}
}

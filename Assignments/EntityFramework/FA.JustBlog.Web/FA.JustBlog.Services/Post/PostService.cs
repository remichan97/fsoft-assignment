using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Post
{
	public class PostService : IPostService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PostService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task<IEnumerable<Posts>> GetAllPosts()
		{
			return await _unitOfWork.PostsRepository.GetPublishedPosts();
		}

		public async Task<IEnumerable<Posts>> GetLatestPosts(int size)
		{
			return await _unitOfWork.PostsRepository.GetLatestPosts(size);

		}

		public async Task<IEnumerable<Posts>> GetMostViewedPosts(int size)
		{
			return await _unitOfWork.PostsRepository.GetMostViewedPosts(size);
		}

		public async Task<IEnumerable<Posts>> GetPostsByCategory(string name)
		{
			return await _unitOfWork.PostsRepository.GetPostsByCategory(name);
		}

		public async Task<IEnumerable<Posts>> GetPostsByTag(string name)
		{
			return await _unitOfWork.PostsRepository.GetPostsByTag(name);
		}

		public async Task<Posts> GetPostsDetails(Guid id)
		{
			return await _unitOfWork.PostsRepository.GetById(id);
		}

		public async Task<Posts> GetPostsDetails(int year, int month, string title)
		{
			return await _unitOfWork.PostsRepository.FindPost(year, month, title);
		}
	}
}

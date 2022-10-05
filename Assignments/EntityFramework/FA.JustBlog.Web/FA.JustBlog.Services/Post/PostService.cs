using FA.JustBlog.Common;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;

namespace FA.JustBlog.Services.Post
{
	public class PostService : IPostService
	{
		private readonly IUnitOfWork _unitOfWork;

		public PostService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddPost(PostCreateVM post)
		{
			var posts = new Posts
			{
				Id = Guid.NewGuid(),
				Title = post.Title,
				ShortDescription = post.ShortDescription,
				Meta = post.Meta,
				Published = post.Published,
				UrlSlug = SeoUrlHepler.FrientlyUrl(post.Title),
				CategoriesId = post.CategoriesId,
				PostedOn = DateTime.Now,
				PostTags = new List<PostTag>()
			};
			foreach (var item in post.TagId)
			{
				posts.PostTags.Add(new PostTag() { TagId = item });
			}
			posts.PostContent = post.PostContent;

			await _unitOfWork.PostsRepository.Add(posts);
			await _unitOfWork.SaveChanges();

		}

		public async Task DeletePost(Guid postId)
		{
			_unitOfWork.PostsRepository.Delete(postId);
			await _unitOfWork.SaveChanges();
		}

		public async Task EditPost(PostCreateVM post, Guid id)
		{
			var data = await _unitOfWork.PostsRepository.GetById(id);

			if (data is null)
			{
				throw new InvalidOperationException("The Post doesn't exists");
			}

			data.Title = post.Title;
			data.Meta = post.Meta;
			data.Published = post.Published;
			data.CategoriesId = post.CategoriesId;

			_unitOfWork.PostsRepository.Update(data);
			await _unitOfWork.SaveChanges();
		}

		public async Task<Posts> FindPostById(Guid id)
		{
			return await _unitOfWork.PostsRepository.FindPost(id);
		}

		public async Task<IEnumerable<Posts>> GetAllPosts()
		{
			return await _unitOfWork.PostsRepository.GetAllPosts();
		}

		public async Task<IEnumerable<Posts>> GetLatestPosts(int size)
		{
			return await _unitOfWork.PostsRepository.GetLatestPosts(size);
		}

		public async Task<IEnumerable<Posts>> GetMostInterestingPosts(int size)
		{
			return await _unitOfWork.PostsRepository.GetMostInterestingPosts(size);
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

		public async Task<IEnumerable<Posts>> GetPublishedPosts()
		{
			return await _unitOfWork.PostsRepository.GetPublishedPosts();
		}

		public async Task<IEnumerable<Posts>> GetUnpublishedPosts()
		{
			return await _unitOfWork.PostsRepository.GetUnpublishedPosts();
		}
	}
}
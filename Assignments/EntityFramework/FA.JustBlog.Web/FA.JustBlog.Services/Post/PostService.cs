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

		public IEnumerable<Posts> GetAllPosts()
		{
			return _unitOfWork.PostsRepository.GetAll();
		}
	}
}

using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repository
{
	public class PostTagRepository : BaseRepository<PostTag>, IPostTagRepository
	{
		public PostTagRepository(AppDbContext context) : base(context)
		{
		}

	}
}
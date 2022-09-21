using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.IRepository
{
	public interface ICommentsRepository : IBaseRepository<Comments>
	{
		void AddComment(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody);
		IList<Comments> GetCommentsForPost(Guid postId);
		IList<Comments> GetCommentsForPost(Posts posts);

	}
}
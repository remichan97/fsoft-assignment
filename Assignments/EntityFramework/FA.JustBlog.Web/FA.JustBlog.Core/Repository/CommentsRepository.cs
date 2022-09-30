using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Core.Repository
{
	public class CommentsRepository : BaseRepository<Comments>, ICommentsRepository
	{
		public CommentsRepository(AppDbContext context) : base(context)
		{
		}

		public void AddComment(Guid postId, string commentName, string commentEmail, string commentTitle, string commentBody)
		{
			Comments comments = new Comments();

			comments.PostId = postId;
			comments.Name = commentName;
			comments.Email = commentEmail;
			comments.CommentHeader = commentTitle;
			comments.CommentText = commentBody;

			_DbContext.Comments.Add(comments);
		}

		public IList<Comments> GetCommentsForPost(Guid postId)
		{
			return _DbContext.Comments.Where(it => it.Posts.Id.Equals(postId)).ToList();
		}

		public IList<Comments> GetCommentsForPost(Posts posts)
		{
			return _DbContext.Comments.Where(it => it.Posts.Id.Equals(posts.Id)).ToList();
		}

	}
}
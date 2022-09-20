using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.IRepository;

namespace FA.JustBlog.Core.Infrastructure
{
	public interface IUnitOfWork : IDisposable
    {
        public ICategoriesRepository CategoriesRepository { get; }
        public IPostsRepository PostsRepository { get; }
        public IPostTagRepository PostTagRepository { get; }
        public ICommentsRepository CommentsRepository { get; }
        public ITagsRepository TagsRepository { get; }
		public AppDbContext AppDbContext { get; }
		int SaveChanges();
	}
}
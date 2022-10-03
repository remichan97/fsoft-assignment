using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Repository;

namespace FA.JustBlog.Core.Infrastructure
{
	public class UnitOfWork : IUnitOfWork
	{
		private readonly AppDbContext _context;
		private ICategoriesRepository _categoriesRepository;
		private IPostsRepository _postRepository;
		private IPostTagRepository _postTagRepository;
		private ICommentsRepository _commentRepository;
		private ITagsRepository _tagsRepository;

		public UnitOfWork(AppDbContext context)
		{
			this._context = context;
		}

		public AppDbContext AppDbContext => _context;

		public ICategoriesRepository CategoriesRepository => _categoriesRepository ?? (_categoriesRepository = new CategoriesRepository(_context));

		public IPostsRepository PostsRepository => _postRepository ?? (_postRepository = new PostsRepository(_context));

		public IPostTagRepository PostTagRepository => _postTagRepository ?? (_postTagRepository = new PostTagRepository(_context));

		public ICommentsRepository CommentsRepository => _commentRepository ?? (_commentRepository = new CommentsRepository(_context));

		public ITagsRepository TagsRepository => _tagsRepository ?? (_tagsRepository = new TagsRepository(_context));

		public void Dispose()
		{
			_context.Dispose();
		}

		public async Task<int> SaveChanges()
		{
			return await _context.SaveChangesAsync();
		}
	}
}
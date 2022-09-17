using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

	}
}
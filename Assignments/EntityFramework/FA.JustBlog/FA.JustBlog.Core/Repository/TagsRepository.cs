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
	public class TagsRepository : BaseRepository<Tags>, ITagsRepository
	{
		public TagsRepository(AppDbContext context) : base(context)
		{
		}

	}
}
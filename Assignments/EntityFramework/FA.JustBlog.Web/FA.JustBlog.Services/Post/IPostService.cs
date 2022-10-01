using FA.JustBlog.Core.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Post
{
	public interface IPostService
	{
		IEnumerable<Posts> GetAllPosts();
	}
}

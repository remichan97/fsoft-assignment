using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tag
{
	public interface ITagService
	{
		Task<IEnumerable<Tags>> GetAllTags();
		Task<IEnumerable<SelectListItem>> GetSelectListItems();
		Task AddTag(Tags tag);
		Task EditTag(Tags tag);
		Task DeleteTag(Guid tagId);
	}
}

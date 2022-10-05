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
		Task AddTag(TagCreateVM tag);
		Task EditTag(TagCreateVM tag, Guid id);
		Task DeleteTag(Guid tagId);
		Task<Tags> CheckExists(string name);
		Task<Tags> CheckExists(Guid id);

	}
}

using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Category
{
	public interface ICategoryService
	{
		Task<IEnumerable<Categories>> GetAllCategories();
		Task<IEnumerable<SelectListItem>> GetSelectListItems();
		Task<Categories> CheckExist(Guid id);
		Task<Categories> CheckUrlSlugs(string url);
		Task AddCategory(Categories category);
		Task EditCategory(Categories category);
		Task DeleteCategory(Guid categoryId);
	}
}

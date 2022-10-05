using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;
using FA.JustBlog.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Category
{
	public class CategoryService : ICategoryService
	{
		private readonly IUnitOfWork _unitOfWork;

		public CategoryService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddCategory(Categories category)
		{
			await _unitOfWork.CategoriesRepository.Add(category);
			await _unitOfWork.SaveChanges();
		}

		public async Task DeleteCategory(Guid categoryId)
		{
			_unitOfWork.CategoriesRepository.Delete(categoryId);
			await _unitOfWork.SaveChanges();
		}

		public async Task EditCategory(Categories category)
		{
			_unitOfWork.CategoriesRepository.Update(category);
			await _unitOfWork.SaveChanges();
		}

		public async Task<IEnumerable<SelectListItem>> GetSelectListItems()
		{
			return (await _unitOfWork.CategoriesRepository.GetCategories()).Select(it => new SelectListItem() { Text = it.Name, Value = it.Id.ToString() });
		}

		public async Task<IEnumerable<Categories>> GetAllCategories()
		{
			return await _unitOfWork.CategoriesRepository.GetCategories();
		}

		public async Task<Categories> CheckExist(Guid id)
		{
			return await _unitOfWork.CategoriesRepository.CheckExists(id);
		}
	}
}

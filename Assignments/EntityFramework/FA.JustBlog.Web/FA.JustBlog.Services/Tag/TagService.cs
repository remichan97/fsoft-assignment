using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Tag;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Services.Tag
{
	public class TagService : ITagService
	{
		private readonly IUnitOfWork _unitOfWork;

		public TagService(IUnitOfWork unitOfWork)
		{
			this._unitOfWork = unitOfWork;
		}

		public async Task AddTag(Tags tag)
		{

			await _unitOfWork.TagsRepository.Add(tag);
			await _unitOfWork.SaveChanges();
		}

		public async Task DeleteTag(Guid tagId)
		{
			_unitOfWork.TagsRepository.Delete(tagId);
			await _unitOfWork.SaveChanges();
		}

		public async Task EditTag(Tags tag)
		{
			_unitOfWork.TagsRepository.Update(tag);
			await _unitOfWork.SaveChanges();
		}

		public async Task<IEnumerable<Tags>> GetAllTags()
		{
			return await _unitOfWork.TagsRepository.GetAllTags();
		}

		public async Task<IEnumerable<SelectListItem>> GetSelectListItems()
		{
			return (await _unitOfWork.TagsRepository.GetAllTags()).Select(it => new SelectListItem() { Text = it.Name, Value = it.Id.ToString() });
		}
	}
}

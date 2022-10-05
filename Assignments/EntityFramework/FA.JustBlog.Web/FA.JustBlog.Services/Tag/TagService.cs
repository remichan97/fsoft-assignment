using FA.JustBlog.Common;
using FA.JustBlog.Core.Infrastructure;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Services.Tag;
using FA.JustBlog.ViewModels;
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

		public async Task AddTag(TagCreateVM tag)
		{
			var data = await CheckExists(tag.Name);

			if(data is not null)
			{
				throw new InvalidOperationException("The tag with the given name is already exists");
			}

			Tags addtag = new Tags { Id = Guid.NewGuid(), Name = tag.Name, Description = tag.Description, Count = 0, UrlSlug = SeoUrlHepler.FrientlyUrl(tag.Name) }; 

			await _unitOfWork.TagsRepository.Add(addtag);
			await _unitOfWork.SaveChanges();
		}

		public async Task<Tags> CheckExists(string name)
		{
			return await _unitOfWork.TagsRepository.CheckExists(name);
		}

		public async Task<Tags> CheckExists(Guid id)
		{
			return await _unitOfWork.TagsRepository.CheckExists(id);
		}

		public async Task DeleteTag(Guid tagId)
		{
			_unitOfWork.TagsRepository.Delete(tagId);
			await _unitOfWork.SaveChanges();
		}

		public async Task EditTag(TagCreateVM tag, Guid id)
		{
			var tags = await _unitOfWork.TagsRepository.CheckExists(id);

			if (tags is null)
			{
				throw new InvalidOperationException("The tag does not exists");
			}

			tags.Name = tag.Name;
			tags.Description = tag.Description;

			_unitOfWork.TagsRepository.Update(tags);
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

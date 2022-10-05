using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FA.JustBlog.ViewModels
{
    public class PostCreateVM
    {
		[Required(ErrorMessage = " Please enter a post title")]
		[StringLength(255)]
		public string Title { get; set; }

		[Required]
		[StringLength(255)]
		[Display(Name = "Short Description")]
		public string ShortDescription { get; set; }

		[Required]
		[StringLength(255)]
		public string Meta { get; set; }

		[Display(Name = "Publish the post?")]
		public bool Published { get; set; }

		[Required]
		[Display(Name = "Category")]
		public Guid CategoriesId { get; set; }

		[Required]
		[Display(Name = "Tags")]
		public List<Guid> TagId { get; set; }
		[Required]
		[Display(Name = "Content")]
		public string PostContent { get; set; }
	}
}

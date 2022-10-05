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
		public string ShortDescription { get; set; }

		[Required]
		[StringLength(255)]
		public string Meta { get; set; }

		[Required]
		[Display(Name = "SEO")]
		public string UrlSlug { get; set; }

		public bool Published { get; set; }

		public Guid CategoryId { get; set; }

		public List<Guid> TagId { get; set; }
	}
}

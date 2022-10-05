using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.ViewModels
{
	public class TagCreateVM
    {
		[StringLength(255)]
		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string UrlSlug { get; set; }

		[Required]
		[StringLength(5000)]
		public string Description { get; set; }
	}
}

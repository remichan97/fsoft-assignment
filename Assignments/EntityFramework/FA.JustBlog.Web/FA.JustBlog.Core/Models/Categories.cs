using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
	public class Categories
	{
		public Guid Id { get; set; } = Guid.NewGuid();

		[StringLength(255)]
		[Required(ErrorMessage = "Please enter a name")]
		public string Name { get; set; }

		[Required]
		[StringLength(255)]
		public string UrlSlug { get; set; }

		[Required]
		[StringLength(5000)]
		public string Description { get; set; }

		public ICollection<Posts> Posts { get; set; } = new List<Posts>();
	}
}
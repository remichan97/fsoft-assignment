using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
	public class Tags
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
		[Required]
		public string Name { get; set; }
		[Required]
		[Display(Name = "SEO Name")]
		public string UrlSlug { get; set; }
		[Required]
		public string Description { get; set; }
		public int Count { get; set; }
		public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
	}
}
using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Core.Models
{
	public class Tags
	{
		[Key]
		public Guid Id { get; set; } = Guid.NewGuid();
		public string Name { get; set; }
		public string UrlSlug { get; set; }
		public string Description { get; set; }
		public int Count { get; set; }
		public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
	}
}
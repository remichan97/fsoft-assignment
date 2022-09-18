using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
	public class Comments
	{
		public Guid Id { get; set; } = Guid.NewGuid();
		[StringLength(255)]
		public string Name { get; set; }
		[StringLength(255)]
		public string Email { get; set; }
		[ForeignKey("Posts")]
		public Guid PostId { get; set; }
		public virtual Posts Posts { get; set; }
		[StringLength(255)]
		public string CommentHeader { get; set; }
		[StringLength(255)]
		public string CommentText { get; set; }
		public DateTime CommentTime { get; set; } = DateTime.Now;
	}
}
using System.ComponentModel.DataAnnotations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class Posts
    {
		public Guid Id { get; set; } = Guid.NewGuid();
        [Required(ErrorMessage = " Please enter a post title")]
        [StringLength(255)]
        public string Title { get; set; }
        [StringLength(255)]
        public string ShortDescription { get; set; }
        [StringLength(255)]
        public string Meta { get; set; }
        public bool Published { get; set; }
        public DateTime PostedOn { get; set; }
        public virtual Categories Categories { get; set; }
        public int ViewCount { get; set; }
        public double RateCount { get; set; }
        public double TotalRate { get; set; }
        [StringLength(5000)]
        public string PostContent { get; set; }
		public virtual ICollection<PostTag> PostTags { get; set; } = new List<PostTag>();
		public virtual ICollection<Comments> Comments { get; set; } = new List<Comments>();
	}
}
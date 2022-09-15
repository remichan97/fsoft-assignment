using System.ComponentModel.DataAnnotations.Schema;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class PostTag
    {
        [ForeignKey("Posts")]
        public Guid PostId { get; set; }
        public virtual Posts Posts { get; set; }
        [ForeignKey("Tags")]
		public Guid TagId { get; set; }
        public virtual Tags Tags { get; set; }
	}
}
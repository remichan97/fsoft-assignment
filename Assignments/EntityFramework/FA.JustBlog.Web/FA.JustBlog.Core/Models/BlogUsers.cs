using Microsoft.AspNetCore.Identity;

namespace FA.JustBlog.Core.Models
{
	public class BlogUsers : IdentityUser
	{
		public string FirstName { get; set; }
		public string LastName { get; set; }
	}
}
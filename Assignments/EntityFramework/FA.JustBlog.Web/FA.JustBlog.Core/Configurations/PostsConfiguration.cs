using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Core.Configurations
{
	public class PostsConfiguration : IEntityTypeConfiguration<Posts>
	{
		public void Configure(EntityTypeBuilder<Posts> builder)
		{
			builder.HasIndex(it => it.UrlSlug).IsUnique();
		}
	}
}
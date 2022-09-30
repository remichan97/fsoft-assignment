using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Core.Configurations
{
	public class TagsConfiguration : IEntityTypeConfiguration<Tags>
	{
		public void Configure(EntityTypeBuilder<Tags> builder)
		{
			builder.HasIndex(it => it.UrlSlug).IsUnique();
		}
	}
}
using FA.JustBlog.Common.Constants;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Common.Configurations
{
	public class RoleSeedConfiguration : IEntityTypeConfiguration<IdentityRole>
	{
		public void Configure(EntityTypeBuilder<IdentityRole> builder)
		{
			builder.HasData(
		new IdentityRole
		{
			Id = "7786d32d-f3eb-444c-bb70-6e8172ab019c",
			Name = Role.BlogOwner,
			NormalizedName = Role.BlogOwner.ToUpper()
		},
		new IdentityRole
		{
			Id = "95a1cdb8-09ca-4a78-8e97-23d111568fa8",
			Name = Role.User,
			NormalizedName = Role.User.ToUpper()
		},
		new IdentityRole
		{
			Id = "3f685516-1abd-4315-8831-a5a03c58e76f",
			Name = Role.Contributor,
			NormalizedName = Role.Contributor.ToUpper()
		});
		}
	}
}
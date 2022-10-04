using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Common.Configurations
{
	public class UserRoleSeedConfiguration : IEntityTypeConfiguration<IdentityUserRole<string>>
	{
		public void Configure(EntityTypeBuilder<IdentityUserRole<string>> builder)
		{
			builder.HasData(
				new IdentityUserRole<string>
				{
					RoleId = "7786d32d-f3eb-444c-bb70-6e8172ab019c",
					UserId = "5d8610ce-c87e-44de-b63d-db947edc8a16"
				},
				new IdentityUserRole<string>
				{
					RoleId = "7786d32d-f3eb-444c-bb70-6e8172ab019c",
					UserId = "3c97c3a6-5626-445c-a7cc-df5da48b7df7"
				},
				new IdentityUserRole<string>
				{
					RoleId = "7786d32d-f3eb-444c-bb70-6e8172ab019c",
					UserId = "149d42c3-9385-467c-934b-1d4d18b415b5"
				},
				new IdentityUserRole<string>
				{
					RoleId = "3f685516-1abd-4315-8831-a5a03c58e76f",
					UserId = "f91b9d5b-cb78-4410-9eda-a085f3219e7b"
				},
				new IdentityUserRole<string>
				{
					RoleId = "3f685516-1abd-4315-8831-a5a03c58e76f",
					UserId = "017888d8-e46a-4a2f-b207-7df331fe49e4"
				},
				new IdentityUserRole<string>
				{
					RoleId = "3f685516-1abd-4315-8831-a5a03c58e76f",
					UserId = "7ee8dfab-7cf9-4f1b-b9ea-5f92e11af797"
				},
				new IdentityUserRole<string>
				{
					RoleId = "95a1cdb8-09ca-4a78-8e97-23d111568fa8",
					UserId = "e52e436f-03f8-4d09-911e-60c7b41e58ab"
				},
				new IdentityUserRole<string>
				{
					RoleId = "95a1cdb8-09ca-4a78-8e97-23d111568fa8",
					UserId = "d77e4bf3-a0a1-4eb5-9e61-901b51dfcd4d"
				},
				new IdentityUserRole<string>
				{
					RoleId = "95a1cdb8-09ca-4a78-8e97-23d111568fa8",
					UserId = "c3cb4a1a-eaf3-4f18-9626-2e72301b8bd1"
				}
				);
		}
	}
}
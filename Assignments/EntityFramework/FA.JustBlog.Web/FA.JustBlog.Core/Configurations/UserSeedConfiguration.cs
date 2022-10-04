using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace FA.JustBlog.Common.Configurations
{
	public class UserSeedConfiguration : IEntityTypeConfiguration<BlogUsers>
	{
		public void Configure(EntityTypeBuilder<BlogUsers> builder)
		{
			var hasher = new PasswordHasher<BlogUsers>();

			builder.HasData(
				new BlogUsers
				{
					Id = "5d8610ce-c87e-44de-b63d-db947edc8a16",
					Email = "admin@localhost.com",
					NormalizedEmail = "ADMIN@LOCALHOST.COM",
					UserName = "admin@localhost.com",
					NormalizedUserName = "ADMIN@LOCALHOST.COM",
					FirstName = "System",
					LastName = "Admin",
					PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
				new BlogUsers {
					Id = "3c97c3a6-5626-445c-a7cc-df5da48b7df7",
                    Email = "mod1@localhost.com",
                    NormalizedEmail = "MOD1@LOCALHOST.COM",
					UserName = "mod1@localhost.com",
					NormalizedUserName = "MOD1@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "Administrator 2",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
			    new BlogUsers{
					Id = "149d42c3-9385-467c-934b-1d4d18b415b5",
                    Email = "mod2@localhost.com",
                    NormalizedEmail = "MOD2@LOCALHOST.COM",
					UserName = "mod2@localhost.com",
					NormalizedUserName = "MOD2@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "Administrator 3",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
				new BlogUsers {
					Id = "f91b9d5b-cb78-4410-9eda-a085f3219e7b",
                    Email = "contributor@localhost.com",
                    NormalizedEmail = "CONTRIBUTOR@LOCALHOST.COM",
					UserName = "contributor@localhost.com",
					NormalizedUserName = "CONTRIBUTOR@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "Contrubutor 1",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
			    new BlogUsers{
					Id = "017888d8-e46a-4a2f-b207-7df331fe49e4",
                    Email = "contributor2@localhost.com",
                    NormalizedEmail = "CONTRIBUTOR2@LOCALHOST.COM",
					UserName = "contributor2@localhost.com",
					NormalizedUserName = "CONTRIBUTOR2@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "Contributor 2",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
			    new BlogUsers{
					Id = "7ee8dfab-7cf9-4f1b-b9ea-5f92e11af797",
                    Email = "contributor3@localhost.com",
                    NormalizedEmail = "CONTRIBUTOR3@LOCALHOST.COM",
					UserName = "contributor3@localhost.com",
					NormalizedUserName = "CONTRIBUTOR3@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "Contributor 3",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
			    new BlogUsers{
					Id = "e52e436f-03f8-4d09-911e-60c7b41e58ab",
                    Email = "user1@localhost.com",
                    NormalizedEmail = "USER1@LOCALHOST.COM",
					UserName = "user1@localhost.com",
					NormalizedUserName = "USER1@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "User 1",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
		        new BlogUsers{
					Id = "d77e4bf3-a0a1-4eb5-9e61-901b51dfcd4d",
                    Email = "user2@localhost.com",
                    NormalizedEmail = "USER2@LOCALHOST.COM",
					UserName = "user2@localhost.com",
					NormalizedUserName = "USER2@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "User 2",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				},
			    new BlogUsers{
					Id = "c3cb4a1a-eaf3-4f18-9626-2e72301b8bd1",
                    Email = "user3@localhost.com",
                    NormalizedEmail = "USER3@LOCALHOST.COM",
					UserName = "user3@localhost.com",
					NormalizedUserName = "USER3@LOCALHOST.COM",
					FirstName = "System",
                    LastName = "User 3",
                    PasswordHash = hasher.HashPassword(null, "remich@n97"),
				}
				);
		}
	}
}
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data
{
	public static class AppDataInitialiser
	{
		public static void SeedData(this ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Categories>().HasData(
				new Categories
				{
					Id = Guid.Parse("37b2a62e-b9b8-456c-bcce-6c30c696575f"),
					Name = "Category 1",
					Description = "Demo category",
					UrlSlug = "cat-1"
				},
				new Categories
				{
					Id = Guid.Parse("59918479-bfae-4794-8477-b5c0f4ad05e2"),
					Name = "Category 2",
					Description = "Demo category",
					UrlSlug = "cat-2"
				},
				new Categories
				{
					Id = Guid.Parse("0549b13b-668a-4556-8176-e3d9abbbbefe"),
					Name = "Category 3",
					Description = "Demo category",
					UrlSlug = "cat-3"
				}
			);

			modelBuilder.Entity<Posts>().HasData(
			new Posts
			{
				Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"),
				Title = "A Post number 1",
				Meta = "Test",
				UrlSlug = "post-1",
				Published = true,
				PostedOn = DateTime.Now,
				ViewCount = 100,
				RateCount = 4.5,
				ShortDescription = "A Short Desc",
				CategoriesId = Guid.Parse("37b2a62e-b9b8-456c-bcce-6c30c696575f"),
				TotalRate = 50,
				PostContent = "A whatever text here"
			},
			new Posts
			{
				Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),
				Title = "A Post number 2",
				Meta = "Test",
				UrlSlug = "post-2",
				Published = true,
				PostedOn = DateTime.Now,
				ViewCount = 100,
				RateCount = 4.5,
				ShortDescription = "A Short Desc",
				CategoriesId = Guid.Parse("37b2a62e-b9b8-456c-bcce-6c30c696575f"),
				TotalRate = 50,
				PostContent = "A whatever text here"
			},
			new Posts
			{
				Id = Guid.Parse("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"),
				Title = "A Post number 3",
				Meta = "Test",
				UrlSlug = "post-3",
				Published = false,
				ShortDescription = "A Short Desc",
				PostedOn = Convert.ToDateTime("2022/04/05"),
				CategoriesId = Guid.Parse("59918479-bfae-4794-8477-b5c0f4ad05e2"),
				PostContent = "A whatever text here"
			}
			);

			modelBuilder.Entity<Tags>().HasData(
			new Tags
			{
				Id = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0"),
				Name = "Tag1",
				UrlSlug = "tag-1",
				Description = "A Demo tag"
			},
			new Tags
			{
				Id = Guid.Parse("ab0cbc9d-14e3-4c3b-a0d7-a28bd2ad471b"),
				Name = "Tag2",
				UrlSlug = "tag-2",
				Description = "A Demo tag"
			},
			new Tags
			{
				Id = Guid.Parse("b32db558-8e83-47f7-94dd-b27678cf98ba"),
				Name = "Tag3",
				UrlSlug = "tag-3",
				Description = "A Demo tag"
			}
			);

			modelBuilder.Entity<Comments>().HasData(
				new Comments
				{
					Name = "A Demo Comment 1",
					Email = "binhtruong@gmail.com",
					CommentHeader = "Header",
					CommentText = "A Comment Body",
					PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede")
				},
				new Comments
				{
					Name = "A Demo Comment 2",
					Email = "binhtruong@gmail.com",
					CommentHeader = "Header",
					CommentText = "A Comment Body",
					PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede")
				},
				new Comments
				{
					Name = "A Demo Comment 3",
					Email = "binhtruong@gmail.com",
					CommentHeader = "Header",
					CommentText = "A Comment Body",
					PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede")
				}
			);

			modelBuilder.Entity<PostTag>().HasData(
				new PostTag
				{
					PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"),
					TagId = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0")
				},
				new PostTag
				{
					PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"),
					TagId = Guid.Parse("b32db558-8e83-47f7-94dd-b27678cf98ba")
				},
				new PostTag
				{
					PostId = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),
					TagId = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0")
				}
			);
		}
	}
}
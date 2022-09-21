using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FA.JustBlog.Core.UnitTest
{
	public class JustBlogTagsTest
	{
		private TagsRepository repo;

		private Mock<DbSet<Tags>> mockTags;

		private Mock<AppDbContext> mockContext;

		private readonly IQueryable<Tags> tagList = new List<Tags>()
		{
			new Tags {Id = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0"), Name = "Tag1", UrlSlug = "tag-1", Description = "A Demo tag"},
			new Tags {Id = Guid.Parse("ab0cbc9d-14e3-4c3b-a0d7-a28bd2ad471b"), Name = "Tag2", UrlSlug = "tag-2", Description = "A Demo tag"},
			new Tags {Id = Guid.Parse("b32db558-8e83-47f7-94dd-b27678cf98ba"), Name = "Tag3", UrlSlug = "tag-3", Description = "A Demo tag"}
		}.AsQueryable();

		[SetUp]
		public void Setup()
		{
			mockTags = new Mock<DbSet<Tags>>();
			mockTags.As<IQueryable<Tags>>().Setup(m => m.Provider).Returns(tagList.Provider);
			mockTags.As<IQueryable<Tags>>().Setup(m => m.Expression).Returns(tagList.Expression);
			mockTags.As<IQueryable<Tags>>().Setup(m => m.ElementType).Returns(tagList.ElementType);
			mockTags.As<IQueryable<Tags>>().Setup(m => m.GetEnumerator()).Returns(() => tagList.GetEnumerator());

			mockContext = new Mock<AppDbContext>();
			mockContext.Setup(it => it.Set<Tags>()).Returns(value: mockTags.Object);
			mockContext.Object.Tags = mockContext.Object.Set<Tags>();

			repo = new TagsRepository(mockContext.Object);
		}

		[Test]
		public void GetTagsByUrlSlugs_WhenPassingExistedUrlSlugs_ReturnTag()
		{
			var repo = new TagsRepository(mockContext.Object);

			var data = repo.GetTagsByUrlSlugs("tag-1");

			Assert.IsNotNull(data);
		}

		[Test]
		public void GetTagsByUrlSlugs_WhenPassingNonExistedUrlSlugs_ReturnNull()
		{
			var repo = new TagsRepository(mockContext.Object);

			var data = repo.GetTagsByUrlSlugs("tag-5");

			Assert.IsNull(data);
		}
	}
}
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;

namespace FA.JustBlog.Core.UnitTest;

public class Tests
{
	private Mock<DbSet<Posts>> mockPosts;

	private Mock<DbSet<Tags>> mockTags;

	private Mock<DbSet<PostTag>> mockPostTag;
	private Mock<AppDbContext> mockContext;

	private IQueryable<Posts> postList = new List<Posts>() {
		new Posts{Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here"},
		new Posts{Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),Title = "A Post number 2", Meta = "Test", UrlSlug = "post-2", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here"},
		new Posts{Id = Guid.Parse("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"),Title = "A Post number 3", Meta = "Test", UrlSlug = "post-3", Published = false, PostedOn = Convert.ToDateTime("2022/04/05"), Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat2"}, ViewCount = 100, RateCount = 4.5, TotalRate = 50, PostContent = "A whatever text here"},
	}.AsQueryable();

	private IQueryable<Tags> tagList = new List<Tags>()
	{
		new Tags {Id = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0"),Name = "Tag1", UrlSlug = "tag-1", Description = "A Demo tag"},
		new Tags {Id = Guid.Parse("ab0cbc9d-14e3-4c3b-a0d7-a28bd2ad471b"), Name = "Tag2", UrlSlug = "tag-2", Description = "A Demo tag"},
		new Tags {Id = Guid.Parse("b32db558-8e83-47f7-94dd-b27678cf98ba"),Name = "Tag3", UrlSlug = "tag-3", Description = "A Demo tag"}
	}.AsQueryable();

	private IQueryable<PostTag> postTags = new List<PostTag>()
	{
		new PostTag {PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), TagId = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0")},
		new PostTag {PostId = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), TagId = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0")},
	}.AsQueryable();

	[SetUp]
	public void Setup()
	{
		mockPosts = new Mock<DbSet<Posts>>();
		mockPosts.As<IQueryable<Posts>>().Setup(m => m.Provider).Returns(postList.Provider);
		mockPosts.As<IQueryable<Posts>>().Setup(m => m.Expression).Returns(postList.Expression);
		mockPosts.As<IQueryable<Posts>>().Setup(m => m.ElementType).Returns(postList.ElementType);
		mockPosts.As<IQueryable<Posts>>().Setup(m => m.GetEnumerator()).Returns(() => postList.GetEnumerator());

		mockTags = new Mock<DbSet<Tags>>();
		mockTags.As<IQueryable<Tags>>().Setup(m => m.Provider).Returns(tagList.Provider);
		mockTags.As<IQueryable<Tags>>().Setup(m => m.Expression).Returns(tagList.Expression);
		mockTags.As<IQueryable<Tags>>().Setup(m => m.ElementType).Returns(tagList.ElementType);
		mockTags.As<IQueryable<Tags>>().Setup(m => m.GetEnumerator()).Returns(() => tagList.GetEnumerator());

		mockPostTag = new Mock<DbSet<PostTag>>();
		mockPostTag.As<IQueryable<PostTag>>().Setup(m => m.Provider).Returns(postTags.Provider);
		mockPostTag.As<IQueryable<PostTag>>().Setup(m => m.Expression).Returns(postTags.Expression);
		mockPostTag.As<IQueryable<PostTag>>().Setup(m => m.ElementType).Returns(postTags.ElementType);
		mockPostTag.As<IQueryable<PostTag>>().Setup(m => m.GetEnumerator()).Returns(() => postTags.GetEnumerator());

		mockContext = new Mock<AppDbContext>();
		mockContext.Setup(it => it.Set<Posts>()).Returns(mockPosts.Object);


	}

	[Test]
	public void GetPublishedPosts_ReturnPublishedPosts()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetPublishedPosts();

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetPublishedPosts_ReturnUnpublishedPosts()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetUnpublishedPosts();

		Assert.AreEqual(1, data.Count);
	}

	[Test]
	public void GetPostsByMonth_ReturnsPostsMadeOnThatMonth()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetPostsByMonth(DateTime.Today);

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetLatestPosts_WhenPassedNegativeInteger_ReturnEmpty()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetLatestPosts(-1);

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void GetLatestPosts_WhenPassedANumberMoreThanRowCount_ReturnAllPosts()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetLatestPosts(5);

		Assert.AreEqual(postList.Count(), data.Count);
	}

	[Test]
	public void CountPostsByCategory_ReturnsNumberOfPostsInCategory()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.CountPostsByCategory("Cat1");

		Assert.AreEqual(2, data);
	}

	[Test]
	public void CountPostsByCategory_WhenEnterNonExistenceCategory_ReturnsZero()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.CountPostsByCategory("Cat4");

		Assert.AreEqual(0, data);
	}

	[Test]
	public void GetPostsByCategory_ReturnPostsBelongsToCategory()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetPostsByCategory("Cat1");

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetPostsByCategory_WhenEnterNonExistenceCategory_ReturnEmpty()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetPostsByCategory("Cat4");

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void GetPostsByTag_WhenPassingExistedTags_ReturnPostsMatchedTags()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetPostsByTag("tag-1");

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetPostsByTag_WhenPassingNonExistedTags_ReturnEmpty()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.GetPostsByTag("tag-7");

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void FindPost_ReturnsPostMatchCriteria()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.FindPost(2022, 4, "post-3");

		Assert.IsNotNull(data);
	}

	[Test]
	public void FindPost_ReturnsNullIfNotFoundForCriteria()
	{
		var repo = new PostsRepository(mockContext.Object);

		var data = repo.FindPost(2022, 4, "post-1");

		Assert.IsNull(data);
	}

}
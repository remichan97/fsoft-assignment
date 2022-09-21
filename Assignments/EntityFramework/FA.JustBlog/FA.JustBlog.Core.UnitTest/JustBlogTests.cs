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
	private Mock<DbSet<Comments>> mockComment;

	private Mock<AppDbContext> mockContext;

	private PostsRepository repo;

	private IQueryable<Posts> postList = new List<Posts>() {
		new Posts  {Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here" },
		new Posts { Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), Title = "A Post number 2", Meta = "Test", UrlSlug = "post-2", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here" },
		new Posts { Id = Guid.Parse("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"), Title = "A Post number 3", Meta = "Test", UrlSlug = "post-3", Published = false, PostedOn = Convert.ToDateTime("2022/04/05"), Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat2"}, ViewCount = 100, RateCount = 4.5, TotalRate = 50, PostContent = "A whatever text here" },
	}.AsQueryable();

	private IQueryable<Tags> tagList = new List<Tags>()
	{
		new Tags {Id = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0"), Name = "Tag1", UrlSlug = "tag-1", Description = "A Demo tag"},
		new Tags {Id = Guid.Parse("ab0cbc9d-14e3-4c3b-a0d7-a28bd2ad471b"), Name = "Tag2", UrlSlug = "tag-2", Description = "A Demo tag"},
		new Tags {Id = Guid.Parse("b32db558-8e83-47f7-94dd-b27678cf98ba"), Name = "Tag3", UrlSlug = "tag-3", Description = "A Demo tag"}
	}.AsQueryable();

	private IQueryable<PostTag> postTags = new List<PostTag>()
	{
		new PostTag {PostId = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), TagId = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0")},
		new PostTag {PostId = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), TagId = Guid.Parse("80fa9998-ca7b-4971-bce1-15f0688034c0")},
	}.AsQueryable();

	private IQueryable<Comments> commentsList = new List<Comments>()
	{
		new Comments {Name = "A Demo Comment 1", Posts = new Posts{Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here"}, Email = "binhtruong@gmail.com", CommentHeader = "Header", CommentText = "A Comment Body"},
		new Comments {Name = "A Demo Comment 2", Posts = new Posts{Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 2", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here"}, Email = "binhtruong@gmail.com", CommentHeader = "Header", CommentText = "A Comment Body"},
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

		mockComment = new Mock<DbSet<Comments>>();
		mockComment.As<IQueryable<Comments>>().Setup(m => m.Provider).Returns(commentsList.Provider);
		mockComment.As<IQueryable<Comments>>().Setup(m => m.Expression).Returns(commentsList.Expression);
		mockComment.As<IQueryable<Comments>>().Setup(m => m.ElementType).Returns(commentsList.ElementType);
		mockComment.As<IQueryable<Comments>>().Setup(m => m.GetEnumerator()).Returns(() => commentsList.GetEnumerator());


		mockContext = new Mock<AppDbContext>();
		mockContext.Setup(it => it.Set<Posts>()).Returns(value: mockPosts.Object);
		mockContext.Setup(it => it.Set<PostTag>()).Returns(value: mockPostTag.Object);
		mockContext.Setup(it => it.Set<Tags>()).Returns(value: mockTags.Object);
		mockContext.Setup(it => it.Set<Comments>()).Returns(value: mockComment.Object);

		mockContext.Object.Posts = mockContext.Object.Set<Posts>();
		mockContext.Object.PostTags = mockContext.Object.Set<PostTag>();
		mockContext.Object.Tags = mockContext.Object.Set<Tags>();
		mockContext.Object.Comments = mockContext.Object.Set<Comments>();


		repo = new PostsRepository(mockContext.Object);
	}

	[Test]
	public void GetPublishedPosts_ReturnPublishedPosts()
	{

		var data = repo.GetPublishedPosts();

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetPublishedPosts_ReturnUnpublishedPosts()
	{
		var data = repo.GetUnpublishedPosts();

		Assert.AreEqual(1, data.Count);
	}

	[Test]
	public void GetPostsByMonth_ReturnsPostsMadeOnThatMonth()
	{
		var data = repo.GetPostsByMonth(DateTime.Today);

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetLatestPosts_WhenPassedNegativeInteger_ReturnEmpty()
	{
		var data = repo.GetLatestPosts(-1);

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void GetLatestPosts_WhenPassedANumberMoreThanRowCount_ReturnAllPosts()
	{
		var data = repo.GetLatestPosts(5);

		Assert.AreEqual(postList.Count(), data.Count);
	}

	[Test]
	public void CountPostsByCategory_ReturnsNumberOfPostsInCategory()
	{
		var data = repo.CountPostsByCategory("Cat1");

		Assert.AreEqual(2, data);
	}

	[Test]
	public void CountPostsByCategory_WhenEnterNonExistenceCategory_ReturnsZero()
	{
		var data = repo.CountPostsByCategory("Cat4");

		Assert.AreEqual(0, data);
	}

	[Test]
	public void GetPostsByCategory_ReturnPostsBelongsToCategory()
	{
		var data = repo.GetPostsByCategory("Cat1");

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetPostsByCategory_WhenEnterNonExistenceCategory_ReturnEmpty()
	{
		var data = repo.GetPostsByCategory("Cat4");

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void GetPostsByTag_WhenPassingExistedTags_ReturnPostsMatchedTags()
	{
		var data = repo.GetPostsByTag("Tag1");

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetPostsByTag_WhenPassingNonExistedTags_ReturnEmpty()
	{
		var data = repo.GetPostsByTag("Tag7");

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void FindPost_ReturnsPostMatchCriteria()
	{
		var data = repo.FindPost(2022, 4, "post-3");

		Assert.IsNotNull(data);
	}

	[Test]
	public void FindPost_ReturnsNullIfNotFoundForCriteria()
	{
		var data = repo.FindPost(2022, 4, "post-1");

		Assert.IsNull(data);
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

	[Test]
	public void GetCommentsForPost_WhenPassingValidPostId_ReturnsCommentsForRespectivePost()
	{
		var repo = new CommentsRepository(mockContext.Object);

		var data = repo.GetCommentsForPost(Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"));

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetCommentsForPost_WhenPassingNonExistsPostId_ReturnsEmpty()
	{
		var repo = new CommentsRepository(mockContext.Object);

		var data = repo.GetCommentsForPost(Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aedd"));

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void GetCommentsForPost_WhenPassAnExistPostObject_ReturnCommentsForPost()
	{
		var repo = new CommentsRepository(mockContext.Object);

		Posts postData = new Posts { Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories { Id = Guid.NewGuid(), Name = "Cat1" }, TotalRate = 50, PostContent = "A whatever text here" };

		var data = repo.GetCommentsForPost(postData);

		Assert.AreEqual(2, data.Count);
	}

	[Test]
	public void GetCommentsForPost_WhenPassANonExistPostObject_ReturnEmptyList()
	{
		var repo = new CommentsRepository(mockContext.Object);

		Posts postData = new Posts { Id = Guid.Parse("8967f772-a6d7-4ff2-845c-a93c30169aae"), Title = "A Post number 6", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories { Id = Guid.NewGuid(), Name = "Cat1" }, TotalRate = 50, PostContent = "A whatever text here" };

		var data = repo.GetCommentsForPost(postData);

		Assert.AreEqual(0, data.Count);
	}

	[Test]
	public void GetCommentsForPost_WhenPassAnExistPostObjectWithoutAnyComment_ReturnEmptyList()
	{
		var repo = new CommentsRepository(mockContext.Object);

		Posts postData = new Posts { Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), Title = "A Post number 2", Meta = "Test", UrlSlug = "post-2", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories { Id = Guid.NewGuid(), Name = "Cat1" }, TotalRate = 50, PostContent = "A whatever text here" };

		var data = repo.GetCommentsForPost(postData);

		Assert.AreEqual(0, data.Count);
	}

}
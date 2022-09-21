using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Core.Repository;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FA.JustBlog.Core.UnitTest
{
	public class JustBlogCommentsTests
	{
		private Mock<DbSet<Posts>> mockPosts;
		private Mock<DbSet<Comments>> mockComment;
		private Mock<AppDbContext> mockContext;

		private CommentsRepository repo;

		private readonly IQueryable<Posts> postList = new List<Posts>()
		{
			new Posts  {Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here" },
			new Posts { Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), Title = "A Post number 2", Meta = "Test", UrlSlug = "post-2", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here" },
			new Posts { Id = Guid.Parse("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"), Title = "A Post number 3", Meta = "Test", UrlSlug = "post-3", Published = false, PostedOn = Convert.ToDateTime("2022/04/05"), Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat2"}, ViewCount = 100, RateCount = 4.5, TotalRate = 50, PostContent = "A whatever text here" },
		}.AsQueryable();

		private readonly IQueryable<Comments> commentsList = new List<Comments>()
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

			mockComment = new Mock<DbSet<Comments>>();
			mockComment.As<IQueryable<Comments>>().Setup(m => m.Provider).Returns(commentsList.Provider);
			mockComment.As<IQueryable<Comments>>().Setup(m => m.Expression).Returns(commentsList.Expression);
			mockComment.As<IQueryable<Comments>>().Setup(m => m.ElementType).Returns(commentsList.ElementType);
			mockComment.As<IQueryable<Comments>>().Setup(m => m.GetEnumerator()).Returns(() => commentsList.GetEnumerator());

			mockContext = new Mock<AppDbContext>();
			mockContext.Setup(it => it.Set<Posts>()).Returns(value: mockPosts.Object);
    		mockContext.Setup(it => it.Set<Comments>()).Returns(value: mockComment.Object);

		    mockContext.Object.Comments = mockContext.Object.Set<Comments>();
		    mockContext.Object.Posts = mockContext.Object.Set<Posts>();

			repo = new CommentsRepository(mockContext.Object);
		}

		[Test]
		public void GetCommentsForPost_WhenPassingValidPostId_ReturnsCommentsForRespectivePost()
		{
			var repo = new CommentsRepository(mockContext.Object);

			var data = repo.GetCommentsForPost(Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"));

			Assert.That(data.Count, Is.EqualTo(2));
		}

		[Test]
		public void GetCommentsForPost_WhenPassingNonExistsPostId_ReturnsEmpty()
		{
			var repo = new CommentsRepository(mockContext.Object);

			var data = repo.GetCommentsForPost(Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aedd"));

			Assert.That(data.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetCommentsForPost_WhenPassAnExistPostObject_ReturnCommentsForPost()
		{
			var repo = new CommentsRepository(mockContext.Object);

			Posts postData = new Posts { Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories { Id = Guid.NewGuid(), Name = "Cat1" }, TotalRate = 50, PostContent = "A whatever text here" };

			var data = repo.GetCommentsForPost(postData);

			Assert.That(data.Count, Is.EqualTo(2));
		}

		[Test]
		public void GetCommentsForPost_WhenPassANonExistPostObject_ReturnEmptyList()
		{
			var repo = new CommentsRepository(mockContext.Object);

			Posts postData = new Posts { Id = Guid.Parse("8967f772-a6d7-4ff2-845c-a93c30169aae"), Title = "A Post number 6", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories { Id = Guid.NewGuid(), Name = "Cat1" }, TotalRate = 50, PostContent = "A whatever text here" };

			var data = repo.GetCommentsForPost(postData);

			Assert.That(data.Count, Is.EqualTo(0));
		}

		[Test]
		public void GetCommentsForPost_WhenPassAnExistPostObjectWithoutAnyComment_ReturnEmptyList()
		{
			var repo = new CommentsRepository(mockContext.Object);

			Posts postData = new Posts { Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"), Title = "A Post number 2", Meta = "Test", UrlSlug = "post-2", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories { Id = Guid.NewGuid(), Name = "Cat1" }, TotalRate = 50, PostContent = "A whatever text here" };

			var data = repo.GetCommentsForPost(postData);

			Assert.That(data.Count, Is.EqualTo(0));
		}
	}
}
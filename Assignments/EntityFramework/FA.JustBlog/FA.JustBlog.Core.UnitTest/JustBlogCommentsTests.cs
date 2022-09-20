using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Moq;
using NUnit.Framework;

namespace FA.JustBlog.Core.UnitTest
{
	public class JustBlogCommentsTests
	{
		private Mock<DbSet<Comments>> mockComment;
		private Mock<AppDbContext> mockContext;

		private IQueryable<Posts> postList = new List<Posts>() {
		new Posts{Id = Guid.Parse("18d6c8da-6d80-4b5c-a94f-66e32835aede"), Title = "A Post number 1", Meta = "Test", UrlSlug = "post-1", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here"},
		new Posts{Id = Guid.Parse("8c61ae9e-6ea9-4bfe-bc59-9e75293c3026"),Title = "A Post number 2", Meta = "Test", UrlSlug = "post-2", Published = true, PostedOn = DateTime.Now, ViewCount = 100, RateCount = 4.5, Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat1"}, TotalRate = 50, PostContent = "A whatever text here"},
		new Posts{Id = Guid.Parse("45cf481f-d98c-471e-b235-d0a9f3b0cfcb"),Title = "A Post number 3", Meta = "Test", UrlSlug = "post-3", Published = false, PostedOn = Convert.ToDateTime("2022/04/05"), Categories = new Categories {Id = Guid.NewGuid(), Name = "Cat2"}, ViewCount = 100, RateCount = 4.5, TotalRate = 50, PostContent = "A whatever text here"},
	}.AsQueryable();

		private IQueryable<Comments> postComments = new List<Comments>()
		{
			
		}.AsQueryable();

		[SetUp]
		public void Setup()
		{
		}

		[Test]
		public void Test1()
		{
			Assert.Pass();
		}
	}
}
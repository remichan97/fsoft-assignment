using FA.JustBlog.Core.Configurations;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data
{
	public class AppDbContext : IdentityDbContext
	{
		public AppDbContext()
		{
			//Need this for moq else it would just complaint about Object reference not set to an instance of an object
			// Categories = Set<Categories>();
			// Comments = Set<Comments>();
			// Posts = Set<Posts>();
			// Tags = Set<Tags>();
			// PostTags = Set<PostTag>();
		}

		public AppDbContext(DbContextOptions<AppDbContext> option) : base(option)
		{
		}

		public DbSet<Categories> Categories { get; set; }
		public DbSet<Comments> Comments { get; set; }
		public DbSet<Posts> Posts { get; set; }
		public DbSet<Tags> Tags { get; set; }
		public DbSet<PostTag> PostTags { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			optionsBuilder.UseSqlServer("Server=(LocalDB)\\MSSQLLocalDB;Database=JustBlogs;Trusted_Connection=True;MultipleActiveResultSets=true;");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostsConfiguration).Assembly);
			modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagsConfiguration).Assembly);

			modelBuilder.SeedData();
		}
	}
}
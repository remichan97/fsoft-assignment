using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FA.JustBlog.Core.Configurations;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
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
		}
    }
}
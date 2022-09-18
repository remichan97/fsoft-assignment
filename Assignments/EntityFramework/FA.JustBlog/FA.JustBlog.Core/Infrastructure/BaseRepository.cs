using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FA.JustBlog.Core.Data;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Core.Infrastructure
{
	public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
	{
		protected readonly AppDbContext _DbContext;
		protected DbSet<TEntity> DbSet;

        public BaseRepository(AppDbContext context)
        {
			this._DbContext = context;
			this.DbSet = context.Set<TEntity>();
		}

		public void Add(TEntity entity)
		{
			DbSet.Add(entity);
		}

		public void CreateRange(List<TEntity> entities)
		{
			DbSet.AddRange(entities);
		}

		public void Delete(TEntity entity)
		{
			DbSet.Remove(entity);
		}

		public void Delete(params object[] ids)
		{
			var entities = DbSet.Find(ids);
            if (entities is null) throw new ArgumentException($"{string.Join(";", ids)} does not exists in the {typeof(TEntity).Name} table");
			DbSet.Remove(entities);
		}

		public IEnumerable<TEntity> Find(Func<TEntity, bool> predicate)
		{
			return DbSet.Where(predicate);
		}

		public IEnumerable<TEntity> GetAll()
		{
			return DbSet;
		}

		public TEntity GetById(params object[] primaryKey)
		{
			return DbSet.Find(primaryKey);
		}

		public void Update(TEntity entity)
		{
			DbSet.Update(entity);
		}

		public void UpdateRange(List<TEntity> entities)
		{
			DbSet.UpdateRange(entities);
		}
	}
}
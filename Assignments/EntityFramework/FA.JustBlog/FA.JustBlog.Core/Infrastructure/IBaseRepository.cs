namespace FA.JustBlog.Core.Infrastructure
{
	public interface IBaseRepository<TEntity> where TEntity : class
    {
		void Add(TEntity entity);
		void CreateRange(List<TEntity> entities);
		void Delete(TEntity entity);
		void Delete(params object[] ids);
		void Update(TEntity entity);
        void UpdateRange(List<TEntity> entities);
		IEnumerable<TEntity> GetAll();
		TEntity GetById(params object[] primaryKey);
		IEnumerable<TEntity> Find(Func<TEntity, bool> predicate);
	}
}
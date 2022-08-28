namespace BookingHelper
{
	public class UnitOfWork : IUnitOfWork
	{
		public IQueryable<T> Query<T>()
		{
			return new List<T>().AsQueryable();
		}
	}
}
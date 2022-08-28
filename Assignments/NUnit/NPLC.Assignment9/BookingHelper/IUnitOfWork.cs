namespace BookingHelper
{
	public interface IUnitOfWork
    {
		IQueryable<T> Query<T>();
	}
}
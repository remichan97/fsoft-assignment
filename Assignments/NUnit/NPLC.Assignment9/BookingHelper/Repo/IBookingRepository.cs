namespace BookingHelper.Repo
{
	public interface IBookingRepository
    {
        IQueryable<Booking> GetActiveBookings(int? excludedBookingId = null);
    }
}
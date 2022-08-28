using BookingHelper;
using BookingHelper.Repo;
using Moq;

namespace BookingHelperTests;

[TestFixture]
public class BookingHelperTests
{
	private Mock<IBookingRepository> mock;

	private Booking _booking;

	[SetUp]
	public void Setup()
	{
		mock = new Mock<IBookingRepository>();

		_booking = new Booking
		{
			Id = 2,
			ArrivalDate = new DateTime(2022, 08, 25),
			DepartureDate = new DateTime(2022, 08, 30),
			Reference = "Mirai"
		};
	}

	[Test]
	public void BookingStartAndFinishesBeforeAnExistingBooking_ReturnEmptyString()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>(){
			_booking
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = new DateTime(2022, 08, 10),
			DepartureDate = new DateTime(2022, 08, 15),
			Status = "Active",
			Reference = "None"
		}, mock.Object);

		Assert.That(res, Is.Empty);
	}

	[Test]
	public void BookingStartBeforeAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>() {
			_booking,
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = new DateTime(2022, 8, 20),
			DepartureDate = DateTime.Now.AddDays(2),
			Status = "Active",
			Reference = "None"
		}, mock.Object);

		Assert.That(res, Is.EqualTo("Mirai"));
	}

	[Test]
	public void BookingStartBeforeAndFinishesAfterAnExistingBooking_ReturnExistingBookingReference()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>() {
			_booking
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = new DateTime(2022, 8, 24),
			DepartureDate = DateTime.Now.AddDays(17),
			Status = "Active",
			Reference = "Remi-chan"
		}, mock.Object);

		Assert.That(res, Is.EqualTo("Mirai"));
	}

	[Test]
	public void BookingStartAndFinishesInTheMiddleOfAnExistingBooking_ReturnExistingBookingReference()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>() {
			_booking,
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = DateTime.Now,
			DepartureDate = DateTime.Now.AddDays(3),
			Status = "Active",
			Reference = "Remi-chan"
		}, mock.Object);

		Assert.That(res, Is.EqualTo("Mirai"));
	}

	[Test]
	public void BookingStartInTheMiddleOfAnExistingBookingButFinishedAfter_ReturnExistingBookingReference()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>() {
			_booking,
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = DateTime.Now,
			DepartureDate = DateTime.Now.AddDays(10),
			Status = "Active",
			Reference = "Remi-chan"
		}, mock.Object);

		Assert.That(res, Is.EqualTo("Mirai"));
	}

	[Test]
	public void BookingStartAndFinishesAfterAnExistingBooking_ReturnEmptyString()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>() {
			_booking,
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = new DateTime(2022, 9, 10),
			DepartureDate = new DateTime(2022, 9, 15),
			Status = "Active",
			Reference = "Remi-chan"
		}, mock.Object);

		Assert.That(res, Is.Empty);
	}

	[Test]
	public void BookingOverlapButNewBookingIsCancelled_ReturnEmptyString()
	{
		mock.Setup(it => it.GetActiveBookings(1)).Returns(new List<Booking>() {
			_booking,
		}.AsQueryable());

		var res = BookingHelper.BookingHelper.OverlappingBookingsExist(new Booking
		{
			Id = 1,
			ArrivalDate = DateTime.Now,
			DepartureDate = DateTime.Now.AddDays(3),
			Status = "Cancelled",
			Reference = "Remi-chan"
		}, mock.Object);

		Assert.That(res, Is.Empty);
	}

}
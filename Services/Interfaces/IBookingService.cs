namespace Services.Interfaces;

public interface IBookingService
{
    bool CreateBooking(int userId, int movieId, DateTime bookingDate);
    bool CancelBooking(int bookingId);
    // IEnumerable<BookingDto> GetBookingsByUser(int userId);
}
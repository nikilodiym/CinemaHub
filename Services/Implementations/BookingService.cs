namespace Services.Implementations;

public class BookingService
{
    public bool CreateBooking(int userId, int movieId, DateTime bookingDate)
    {
        return true;
    }

    public bool CancelBooking(int bookingId)
    {
        return true;
    }

    //public IEnumerable<BookingDto> GetBookingsByUser(int userId)
    //{
        //return new List<BookingDto>(); 
    //}
}
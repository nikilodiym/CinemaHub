namespace ViewModels.Booking;

public class BookingViewModel
{
    public int BookingId { get; set; }
    public int UserId { get; set; }
    public int ScreeningId { get; set; }
    public DateTime BookingDate { get; set; }
    public bool IsPaid { get; set; }
}
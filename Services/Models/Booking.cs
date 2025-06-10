namespace Services.Models;

public class Booking
{
    public int BookingId { get; set; }
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public DateTime BookingDate { get; set; }
    public DateTime CreatedAt { get; set; }
}
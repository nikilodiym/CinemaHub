namespace Services.DTOs;

public class BookingDto
{
    public int BookingId { get; set; }
    public int UserId { get; set; }
    public int MovieId { get; set; }
    public DateTime BookingDate { get; set; }
}
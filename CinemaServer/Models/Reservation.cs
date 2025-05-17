namespace CinemaWPF.Core.Models;

public class Reservation
{
    public int Id { get; set; }
    public int MovieId { get; set; }
    public int UserId { get; set; }
    public DateTime ReservationDate { get; set; }
}
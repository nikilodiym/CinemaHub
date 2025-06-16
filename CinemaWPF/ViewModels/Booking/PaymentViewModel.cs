namespace ViewModels.Booking;

public class PaymentViewModel
{
    public int PaymentId { get; set; }
    public int BookingId { get; set; }
    public decimal Amount { get; set; }
    public string PaymentMethod { get; set; }
    public bool IsSuccessful { get; set; }
    public DateTime PaymentDate { get; set; }
}
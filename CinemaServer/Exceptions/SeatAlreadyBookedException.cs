namespace Services.Exceptions;

public class SeatAlreadyBookedException : Exception
{
    public SeatAlreadyBookedException(string message) : base(message) { }
}
namespace Services.Exceptions;

public class FilmNotFoundException : Exception
{
    public FilmNotFoundException(string message) : base(message) { }
}
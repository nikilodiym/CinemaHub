namespace Services.Models;

public class Screening
{
    public int ScreeningId { get; set; }
    public int FilmId { get; set; }
    public DateTime ScreeningTime { get; set; }
    public string Location { get; set; }
}
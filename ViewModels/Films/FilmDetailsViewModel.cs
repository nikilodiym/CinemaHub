namespace ViewModels.Films;

public class FilmDetailsViewModel
{
    public int FilmId { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public DateTime ReleaseDate { get; set; }
    public string Genre { get; set; }
    public double Rating { get; set; }
}
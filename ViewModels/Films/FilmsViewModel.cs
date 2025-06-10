namespace ViewModels.Films;

public class FilmsViewModel
{
    public List<FilmDetailsViewModel> Films { get; set; } = new();
    public int CurrentPage { get; set; }
    public int TotalPages { get; set; }
    public int TotalItems { get; set; }
}
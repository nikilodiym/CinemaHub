namespace CinemaWPF.ViewModels.Films;

public class FilmsViewModel
{
    public string Title { get; set; }
    public int Year { get; set; }
    public string Genre { get; set; }
    public string ImagePath { get; set; } // Шлях до постеру
    public string Description { get; set; }
}
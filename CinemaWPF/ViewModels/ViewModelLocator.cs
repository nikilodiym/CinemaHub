using CinemaWPF.ViewModels.Auth;
using CinemaWPF.ViewModels.Films;

namespace CinemaWPF.ViewModels;

public class ViewModelLocator
{
    public AdminLoginViewModel AdminLoginViewModel { get; } = new AdminLoginViewModel();
    public FilmsViewModel FilmsViewModel { get; } = new FilmsViewModel();
    public FilmDetailsViewModel FilmDetailsViewModel { get; } = new FilmDetailsViewModel(new Core.Models.Movie
    {
        Id = 1,
        Title = "Sample Movie",
        Description = "Sample Description",
        ReleaseDate = DateTime.Now
        
    });
    
}
using System;
using CinemaWPF.Core.Models;

namespace CinemaWPF.ViewModels.Films;

public class FilmDetailsViewModel
{
    public int Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public DateTime ReleaseDate { get; set; }

    public FilmDetailsViewModel(Movie movie)
    {
        Id = movie.Id;
        Title = movie.Title;
        Description = movie.Description;
        ReleaseDate = movie.ReleaseDate;
    }
}
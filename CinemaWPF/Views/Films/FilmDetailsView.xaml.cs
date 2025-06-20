using System.Windows;
using System.Windows.Controls;
using CinemaServer.Services;
using Core.Models;
using Services.Implementations;

namespace CinemaWPF.Views.Films;

public partial class FilmDetailsView : UserControl
{
    public FilmDetailsView()
    {
        InitializeComponent();
    }

    private async void SaveFilmButton_Click(object sender, RoutedEventArgs e)
    {
        var title = FilmTitleTextBox.Text;
        var description = FilmDescriptionTextBox.Text;
        var releaseDate = FilmReleaseDatePicker.SelectedDate;

        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description) || releaseDate == null)
        {
            MessageBox.Show("Please fill in all fields.");
            return;
        }

        var film = new Movie
        {
            Title = title,
            Description = description,
            ReleaseDate = releaseDate.Value
        };

        var movieService = new MovieService();
        try
        {
            await movieService.AddFilmAsync(film);
            MessageBox.Show("Film added successfully!");
            // Оновлення UI або очищення полів за потреби
        }
        catch
        {
            MessageBox.Show("Error adding film.");
        }
    }
}



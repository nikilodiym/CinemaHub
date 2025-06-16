using System.Windows;
using System.Windows.Controls;
using CinemaServer.CinemaSupabase;
using CinemaWPF.Core.Models;

namespace CinemaWPF.Views.Films;

public partial class FilmDetailsView : UserControl
{
    private readonly SupabaseAuthDataProvider _dataProvider;

    public FilmDetailsView()
    {
        InitializeComponent();
        _dataProvider = new SupabaseAuthDataProvider();
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

        var success = await _dataProvider.AddFilmAsync(film);

        if (success)
        {
            MessageBox.Show("Film added successfully!");

            var filmsView = new FilmsView();
            var currentWindow = Window.GetWindow(this);
            if (currentWindow != null)
            {
                currentWindow.Content = filmsView;
            }
        }
        else
        {
            MessageBox.Show("Failed to add film. Please try again.");
        }
    }
}
using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF.Views.Auth;

public partial class AdminLoginView : UserControl
{
    public AdminLoginView()
    {
        InitializeComponent();
    }
    
    private void AddMovieButton_Click(object sender, RoutedEventArgs e)
    {
        string movieName = MovieNameInput.Text;
        string movieYear = MovieYearInput.Text;

        if (string.IsNullOrEmpty(movieName)) // Fixed missing parenthesis
        {
            MessageBox.Show("Please enter a movie title!");
            return;
        }

        // Add the movie to the database or list here
        MessageBox.Show($"Movie added: {movieName} ({movieYear})");

        // Clear the input fields after adding
        MovieNameInput.Clear();
        MovieYearInput.Clear();
    }
}
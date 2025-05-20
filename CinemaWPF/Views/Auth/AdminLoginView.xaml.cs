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

        if (string.IsNullOrEmpty(movieName))
        {
            MessageBox.Show("Please enter a movie title!");
            return;
        }

        MessageBox.Show($"Movie added: {movieName} ({movieYear})");

        MovieNameInput.Clear();
        MovieYearInput.Clear();
    }
}
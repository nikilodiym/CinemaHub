using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF.Views.Films;

public partial class FilmDetailsView : UserControl
{
    public FilmDetailsView()
    {
        InitializeComponent();
        SaveFilmButton.Click += SaveFilmButton_Click;
    }

    private void SaveFilmButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Film details saved!");
        // Add logic for saving film details here
    }
}
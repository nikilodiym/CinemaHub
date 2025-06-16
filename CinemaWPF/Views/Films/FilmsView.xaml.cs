using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF.Views.Films;

public partial class FilmsView : UserControl
{
    public FilmsView()
    {
        InitializeComponent();
        AddFilmButton.Click += AddFilmButton_Click;
    }

    private void AddFilmButton_Click(object sender, RoutedEventArgs e)
    {
        //MessageBox.Show("Add new film functionality triggered!");

        var filmDetailsView = new FilmDetailsView();

        // Заміна вмісту поточного вікна на FilmDetailsView
        var currentWindow = Window.GetWindow(this);
        if (currentWindow != null)
        {
            currentWindow.Content = filmDetailsView;
        }
    }
}
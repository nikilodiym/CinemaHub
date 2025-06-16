using System.Windows.Controls;
using System.Windows;
using CinemaWPF.Views.Films;

namespace CinemaWPF.Views.Auth;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        
        InitializeComponent();
    }
    
    private void UserButton_Click(object sender, RoutedEventArgs e)
    {
        var loginWindow = new LoginWindowView();
        var currentWindow = Window.GetWindow(this);
        if (currentWindow != null)
        {
            currentWindow.Content = loginWindow;
        } 
    }

    private void AdminButton_Click(object sender, RoutedEventArgs e)
    {
        var filmsView = new FilmsView();
    
        var currentWindow = Window.GetWindow(this);
        if (currentWindow != null)
        {
            currentWindow.Content = filmsView;
        } 
    }
}


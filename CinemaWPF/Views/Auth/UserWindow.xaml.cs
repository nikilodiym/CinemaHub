using System.Windows;

namespace CinemaWPF.Views.Auth;

public partial class UserWindow : Window
{
    public UserWindow()
    {
        
        InitializeComponent();
        this.Content = new LoginView();
    }
}
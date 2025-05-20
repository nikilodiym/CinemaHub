using System.Windows.Controls;
using System.Windows;

namespace CinemaWPF.Views.Auth;

public partial class LoginView : UserControl
{
    public LoginView()
    {
        InitializeComponent();
    }
    
    private void UserButton_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Welcome to user mode! Movies loading...");

        var userWindow = new UserWindow();
        userWindow.Show();

        Window.GetWindow(this)?.Close();
    }

    private void AdminButton_Click(object sender, RoutedEventArgs e)
    {
        var adminWindow = new AdminWindow();
        adminWindow.Show();

        Window.GetWindow(this)?.Close();
    }

}
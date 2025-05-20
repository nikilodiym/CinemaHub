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

        // Відкриваємо вікно з користувацьким інтерфейсом
        var userWindow = new UserWindow();
        userWindow.Show();

        // Закриваємо батьківське вікно
        Window.GetWindow(this)?.Close();
    }

    private void AdminButton_Click(object sender, RoutedEventArgs e)
    {
        // Відкриваємо вікно з адмінським інтерфейсом
        var adminWindow = new AdminWindow();
        adminWindow.Show();

        // Закриваємо батьківське вікно
        Window.GetWindow(this)?.Close();
    }

}
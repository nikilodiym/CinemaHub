using System.Windows;
using System.Windows.Controls;

namespace CinemaWPF.Views.Auth;

public partial class LoginWindowView : UserControl
{
    public LoginWindowView()
    {
        InitializeComponent();
    }
    
    private void LoginButton_Click(object sender, RoutedEventArgs e)
    {
        // TODO: Реалізувати логіку авторизації через JWT
        MessageBox.Show("Авторизація поки не реалізована");
    }

    private void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var registerWindow = new RegisterWindowView();
            
        var currentWindow = Window.GetWindow(this);
        if (currentWindow != null)
        {
            currentWindow.Content = registerWindow;
        }
    }
}
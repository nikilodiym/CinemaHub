using System.Windows;
using System.Windows.Controls;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using Supabase;

namespace CinemaWPF.Views.Auth;

public partial class RegisterWindowView : UserControl
{
    public RegisterWindowView()
    {
        InitializeComponent();
    }
    private async void RegisterButton_Click(object sender, RoutedEventArgs e)
    {
        var username = UsernameTextBox.Text;
        var password = PasswordBox.Password;
        var confirmPassword = ConfirmPasswordBox.Password;
        if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
        {
            MessageBox.Show("Всі поля обов'язкові!");
            return;
        }
        if (password != confirmPassword)
        {
            MessageBox.Show("Паролі не співпадають!");
            return;
        }
        try
        {
            var supabase = new Supabase.Client(
                "https://nvtstozbbftyzpnjmnyz.supabase.co", 
                "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJzdXBhYmFzZSIsInJlZiI6Im52dHN0b3piYmZ0eXpwbmptbnl6Iiwicm9sZSI6ImFub24iLCJpYXQiOjE3NDc0NzM4NzcsImV4cCI6MjA2MzA0OTg3N30.etGp1-etVKGboYf8s00Nq4T5rM_sxjJxILGT_0zzUxo" 
            );
            var session = await supabase.Auth.SignUp(username, password);
            if (session != null && session.User != null)
            {
                var jwt = session.AccessToken;
                MessageBox.Show("Реєстрація успішна! Тепер увійдіть.");
                var mainWindow = Window.GetWindow(this);
                if (mainWindow != null)
                {
                    mainWindow.Content = new LoginWindowView();
                }
            }
            else
            {
                MessageBox.Show("Невідома помилка реєстрації.");
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Помилка підключення: {ex.Message}");
        }
    }
}

